using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingletonWork;

namespace UserSingleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var singleton1 = Singleton.Instance;

            singleton1.City = "Kyiv";
            singleton1.Date = 120;
            singleton1.Latitude = 50.45;
            singleton1.LatitudeLocation = "N";

            string season = singleton1.DetermineSeason();
            
            Console.WriteLine($"City: {singleton1.City}");
            Console.WriteLine($"Date (day of the year): {singleton1.Date}");
            Console.WriteLine($"Latitude: {singleton1.Latitude}° {singleton1.LatitudeLocation}");
            Console.WriteLine($"Season: {season}");
        }
    }
}
