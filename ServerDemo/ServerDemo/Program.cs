using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // create socket listener
            IPAddress IP = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(IP, 8080);
            TcpClient client = default(TcpClient);

            // connect to server
            try
            {
                server.Start();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Console.Read();
            }

            // capture data sent from client to server
            while (true)
            {
                client = server.AcceptTcpClient();

                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                StringBuilder message = new StringBuilder();
                foreach (byte b in receivedBuffer)
                {
                    if (b.Equals(59)) // 59 = ";"... 00 = null...
                    {
                        break;
                    }
                    else
                    {
                        message.Append(Convert.ToChar(b).ToString());
                    }
                }

                Console.WriteLine(message.ToString());
            }
        }
    }
}
