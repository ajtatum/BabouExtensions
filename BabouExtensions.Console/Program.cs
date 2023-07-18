using System;
using BabouExtensions;

namespace BabouExtensions.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDate = DateTime.Now;
            System.Console.WriteLine(currentDate);

            var easternTime = DateTime.Now.TryGetTimeZoneDateTime("America/New_York");
            System.Console.WriteLine(easternTime);

            var centralTime = DateTime.Now.TryGetTimeZoneDateTime("Central Standard Time");
            System.Console.WriteLine(centralTime);
        }
    }
}
