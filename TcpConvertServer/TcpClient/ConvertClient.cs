using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace TcpClient
{
    class ConvertClient
    {
        private double _weightToConvert;
        private enum Conversion
        {
            ToOunces,
            ToGrams
        }

      

        public decimal Convert(string conversion)
        {
            using (System.Net.Sockets.TcpClient socket = new System.Net.Sockets.TcpClient("localhost", 80))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            {
                String stringtoConvert="";
                decimal placeholder = 0;

                if(conversion == (Conversion.ToGrams).ToString())
                {
                    Console.WriteLine($"sending to gram conversion request {_weightToConvert} ounces");  
                   stringtoConvert=$"{Conversion.ToGrams} {_weightToConvert}" ;

                }
                else if (conversion == (Conversion.ToOunces).ToString())
                {
                    Console.WriteLine($"sending to ounces conversion request {_weightToConvert} grams");
                    stringtoConvert=$"{Conversion.ToOunces} {_weightToConvert}";
                }
                sw.WriteLine(JsonConvert.SerializeObject(stringtoConvert));
                
                sw.Flush();

                return decimal.Parse(sr.ReadLine());
            }

        }

        public ConvertClient(double weightToConvert)
        {
            _weightToConvert = weightToConvert;
        }
    }
}
