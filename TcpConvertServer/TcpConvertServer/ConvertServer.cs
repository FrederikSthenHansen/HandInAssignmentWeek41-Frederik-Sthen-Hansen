using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using assignment1WeightConverter;
using Newtonsoft.Json;

namespace TcpConvertServer
{/// <summary>
/// JsonServer that can convert Grams to ounces and vice verca using the Assignment 1 .DLL 
/// </summary>
     internal class ConvertServer
     {
         private readonly int _port;
         private double _weight;
         private decimal result;

         public ConvertServer(int port)
         {
             this._port = port;
         }

        public void doClient(TcpClient socket)

        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                String incomingJsonStr = sr.ReadLine();
                string incomingString = JsonConvert.DeserializeObject(incomingJsonStr).ToString();
                string[] splitString = incomingString.Split(" ");
                _weight = double.Parse(JsonConvert.DeserializeObject(splitString[1]).ToString());
                double result;
                decimal resultDec;

                if (incomingString.Contains("ToGram"))
                {
                    Console.WriteLine("convert to gram request recieved");
                    result = WeightConverter.OuncesToGrams(_weight);
                    resultDec = decimal.Parse(Math.Round(result, 2).ToString());
                    sw.WriteLine(resultDec);
                } 
                else if (incomingString.Contains("ToOunces"))
                {
                  result = WeightConverter.GramsToOunces(_weight);
                   resultDec = decimal.Parse(Math.Round(result, 2).ToString());
                    sw.WriteLine(resultDec);
                }
                sw.Flush();
            }
        }

         public void Start()
         {
             TcpListener serverListener=new TcpListener(IPAddress.Loopback, _port);
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
