/*
Author: Drake Bertrand
CLID: C00279435
Class: CMPS 358
Assignment: project 2
Due Date: 10/18/22 11:55pm
Description: A client-server application that I was unable to complete in time. "Magic black box" concept of a server
             proved to be too difficult for me to provide a working solution for. 
*/


using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;
using static System.Environment;
using static System.IO.Path;
using System.Security.Cryptography;
using p2server_C00279435;

var clientList = new List<StreamFromClientInput>();
var listen = new TcpListener(IPAddress.Any, 8081);
listen.Start();
Console.WriteLine("Listening for client on 8081 ...");

//SERVER    SERVER    SERVER    SERVER    SERVER    SERVER    SERVER    SERVER    SERVER    

while (true)
{
    var clientConnect = listen.AcceptTcpClient();
    var theClient = clientConnect.GetStream();

    var bw = new BinaryWriter(theClient);
    var br = new BinaryReader(theClient);
    var currentUser = new CurrentClient("ClientConnection");
    
    var sfcInput = new StreamFromClientInput(br, bw, clientList, currentUser, currentUser.publicKey);
    lock (clientList)
    {
        clientList.Add(sfcInput);
    }
}

internal class StreamFromClientInput
{
    private readonly BinaryWriter bw;
    public CurrentClient currentUser;
    public StreamFromClientInput(BinaryReader br, BinaryWriter bw, List<StreamFromClientInput> list, CurrentClient currentUser, string publicKey)
    {
        this.bw = bw;
        this.currentUser = currentUser;
        this.currentUser.publicKey = publicKey;
        Task.Run(() =>  InputLoop(br, list, currentUser, this.currentUser.publicKey));
    }
    
    private async Task InputLoop(BinaryReader br, List<StreamFromClientInput> list, CurrentClient currentUser, string publicKey)
    {
        try
        {
            while (true)
            {
                bw.Write(@"1: Register a new user
2: Send a message to an existing user
3: Get all the messages for a user");
                bw.Flush();
                var incoming = br.ReadString();
                String messageToSend;
                String receiverForMessage;
                if (incoming == "1")
                {
                    bw.Write("Enter new user's username: ");
                    bw.Flush();
                    this.currentUser.userName = br.ReadString();
                    Console.WriteLine($"Username {this.currentUser.userName} has been added");
                    bw.Write($"Username {this.currentUser.userName} has been added");
                    bw.Flush();
                }

                if (incoming == "2")
                {
                    bw.Write("What user would you like to send a message to?  ");
                    bw.Flush();
                    incoming = br.ReadString();
                    bw.Write("Enter a message for the user: ");
                    bw.Flush();
                    messageToSend = br.ReadString();
                    this.currentUser.userMessages.Add(messageToSend);
                    bw.Write($"Sent the message to {incoming}");
                    bw.Flush();
                    Console.WriteLine($"Sent the message to {incoming}");
                }

                if (incoming == "3")
                {
                    bw.Write("Enter a username to get the messages for: ");
                    bw.Flush();
                    incoming = br.ReadString();
                    bw.Write($"Getting the messages for {incoming}");
                    bw.Flush();
                    Console.WriteLine($"Getting the messages for {incoming}");
                    if (this.currentUser.userName == incoming)
                    {
                        foreach (var message in this.currentUser.userMessages)
                        {
                            Console.WriteLine($"{message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unable to access this user's mail. Keys do not match.");
                    }
                }
            }
        }
        catch { }
    }
}

internal class CurrentClient
{
    public List<string> userMessages;
    public string userName { get; set; }
    public string publicKey { get; set; }
    private new Cryptography keys = new Cryptography();
    public CurrentClient(string userName)
    {
        keys.GeneratePublicPrivateKeys();
        this.userName = userName;
        this.userMessages = new List<string>();
        this.publicKey = publicKey;
    }
}