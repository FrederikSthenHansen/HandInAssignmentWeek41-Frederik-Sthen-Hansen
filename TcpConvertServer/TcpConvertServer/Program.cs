using System;

namespace TcpConvertServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server starting...");

            // kommentar til sletning inden aflevering port 7 eller port 80?
            ConvertServer server=new ConvertServer(80);
            server.Start();
        }
    }
}
