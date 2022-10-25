/*
Author: Drake Bertrand
CLID: C00279435
Class: CMPS 358
Assignment: project 2
Due Date: 10/18/22 11:55pm
Description: A client-server application that I was unable to complete in time. "Magic black box" concept of a server
             proved to be too difficult for me to provide a working solution for.
*/



namespace p2server_C00279435;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using static System.Environment;
using static System.IO.Path;

public class Cryptography
{
    
    public void GeneratePublicPrivateKeys()
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            File.WriteAllText(Combine(CurrentDirectory, "PublicKeyOnly.xml"),
                rsa.ToXmlString(false));
            File.WriteAllText(Combine(CurrentDirectory, "PrivateKeyOnly.xml"),
                rsa.ToXmlString(true));
        }
    }

    public void DecryptWithPrivateKey()
    {
        byte[] encryptedMessage = File.ReadAllBytes(Combine(CurrentDirectory, "encryptedmessage"));
        string publicPrivate = File.ReadAllText(Combine(CurrentDirectory, "PrivateKeyOnly.xml"));
        string decryptedMessage;
        byte[] decryptedInBytes;

        using (var rsaPublicPrivate = new RSACryptoServiceProvider())
        {
            rsaPublicPrivate.FromXmlString(publicPrivate);
            decryptedInBytes = rsaPublicPrivate.Decrypt(encryptedMessage, true);
            decryptedMessage = Encoding.UTF8.GetString(decryptedInBytes);
        }
        
        Console.WriteLine($"Decrypted message is: {decryptedMessage}");
    }

    private void EncryptionWithPublicKey()
    {
        Console.Write("Enter message you would like to send: ");
        string message = Console.ReadLine();

        byte[] datain = Encoding.UTF8.GetBytes (message);
        string publicKeyOnly = File.ReadAllText( 
            Combine(CurrentDirectory,"PublicKeyOnly.xml"));

        byte[] encrypted;
        using (var rsaPublicOnly = new RSACryptoServiceProvider())
        {
            rsaPublicOnly.FromXmlString (publicKeyOnly);
            encrypted = rsaPublicOnly.Encrypt (datain, true);
        }
        File.WriteAllBytes(		
            Combine(CurrentDirectory,"encryptedmessage"),encrypted);
    }
}