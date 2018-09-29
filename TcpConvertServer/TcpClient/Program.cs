using System;
using System.Dynamic;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
             ConvertClient c1= new ConvertClient(54.00);
            ConvertClient c2= new ConvertClient(56.50);

            Console.WriteLine(c1.Convert("ToGrams"));
            Console.WriteLine(c2.Convert("ToOunces"));

            Console.ReadLine();

        }
    }
}
