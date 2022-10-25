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
using System.Xml.Xsl;
using p2client_C00279435;
using static System.Environment;
using static System.IO.Path;


//var clientList = new List<StreamFromClientInput>();
ClientValues();

static void ClientValues()
{
    using var serverConnector = new TcpClient("localhost", 8081);
    using var serverConnection = serverConnector.GetStream();
    var bw = new BinaryWriter(serverConnection);
    var br = new BinaryReader(serverConnection);
    new StreamForClientInput(br);
    Console.WriteLine("Please select from the options below.");
    

    try
    {
        while (true)
        {
            var messageToSend = Console.ReadLine();
            bw.Write(messageToSend);
            bw.Flush();
        }
    }
    catch { }
}

internal class StreamForClientInput
{
    public StreamForClientInput(BinaryReader br)
    {
        Task.Run(() => InputLoop(br));
    }

    private async void InputLoop(BinaryReader br)
    {
        try
        {
            while (true)
            {
                var incoming = br.ReadString();
                Console.WriteLine(incoming);
            }
        }
        catch { }
    }
}



//Used to set the values of each individual client through objects and distinct values

internal class ClientValues
{
    public NetworkStream Server;
    public String username { get; set; }
    public TcpClient Connection;
    public BinaryReader br;
    public BinaryWriter bw;
    public List<string> userMessages;
    private new Cryptography userKeys;
    

    public void Client(TcpClient tcpClient)
    {
        this.Connection = tcpClient;
        this.Server = Connection.GetStream();
        this.bw = bw;
        this.br = br;
        this.userMessages = userMessages;
        this.userKeys.GeneratePublicPrivateKey();
    }
}