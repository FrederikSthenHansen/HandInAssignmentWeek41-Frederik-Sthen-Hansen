using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TcpConvertServer
{
     internal class ConvertServer
     {
         private readonly int Port;

         public ConvertServer(int port)
         {
             this.Port = port;
         }

        public void doClient(TcpClient socket)

        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                String incommingStr = sr.ReadLine();
                if (incommingStr.Contains("INDÆT BETINGELSE HER")) ;


            }
        }

         public void Start()
         {
             TcpListener serverListener=new TcpListener(IPAddress.Loopback, Port);
            serverListener.Start();
             while (true)
             {
                 TcpClient socket = serverListener.AcceptTcpClient();
                 Task.Run(() =>
                 {
                     TcpClient tempSocket = socket;
                     doClient(tempSocket);
                 });
             }
         }
    }
}
