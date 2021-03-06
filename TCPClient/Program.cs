using System;
using System.IO;
using System.Net.Sockets;


namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TCP Client");
            Console.WriteLine("enter a Keyword: ");

            //read a line from the console user input 
            string message = Console.ReadLine();

            //initialize a TcpClient to establish a connection to the server
            //The 2 parameters represent the IP Address of the server,
            //and the port number,
            //remember the server was listening on port 7.
            //127.0.0.1 is always the local computer.
            //Change the IP if you want to communicate with another computer.
            TcpClient socket = new TcpClient("127.0.0.1", 7);

            //access the streams to communicate with the server
            NetworkStream networkStream = socket.GetStream();
            StreamReader reader = new StreamReader(networkStream);
            StreamWriter writer = new StreamWriter(networkStream);

            //On the server side, it expected to read a message first,
            //so we need to send a message first on the client side

            writer.WriteLine(message);

            //remember to flush the message clean up, stop sending messages 
            //Clears buffers for this stream and causes any buffered data to be written to the file.
            writer.Flush();

            //read the message that the server responds with
            string response = reader.ReadLine();

            //server responded with
            Console.WriteLine(response);

            //because this is a single use Echo client, you must clean up,
            //by closing the socket

            socket.Close();



        }
    }
}
