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
                Console.WriteLine("Connection successfull!");
                Console.Read();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Console.Read();
            }
        }
    }
}
