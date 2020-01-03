using System;

namespace BabouExtensions.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var convertToCsv1 = "Hello,true,1,there,here\r\nlinebreak,nobreak,Hello".ConvertToCsv(',', ',', null, true, " ", true);
            var convertToCsv2 = "Hello,true,1,there,here\r\nlinebreak,nobreak,Hello".ConvertToCsv(',', ',', null, false, null, false);
            var convertToCsv3 = "Hello,true,1,there,here\r\nlinebreak,nobreak,Hello".ConvertToCsv(',', ',', true, false, null, false);
            var convertToCsv4 = "Hello,true,1,there,here\r\nlinebreak,nobreak,Hello".ConvertToCsv(',', ',', false, false, null, false);


            System.Console.WriteLine(convertToCsv1);
            System.Console.WriteLine(Environment.NewLine);
            System.Console.WriteLine(convertToCsv2);
            System.Console.WriteLine(Environment.NewLine);
            System.Console.WriteLine(convertToCsv3);
            System.Console.WriteLine(Environment.NewLine);
            System.Console.WriteLine(convertToCsv4);
            System.Console.ReadLine();
        }
    }
}
