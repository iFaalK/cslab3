using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonWork
{
    public sealed class Singleton
    {
        private int _date;
        private double _latitude;
        private string _latitudeLocation;
        private string _city;

        public int Date
        {
            get => _date;
            set
            {
                if (value < 1 || value > 365)
                {
                    throw new ArgumentOutOfRangeException("Out of range (1;365)");
                }
                _date = value;
            }
        }

        public double Latitude
        {
            get => _latitude;
            set
            {
                if (value < 0 || value > 90) throw new ArgumentOutOfRangeException("Out of range(0;90)");
                _latitude = value;
            }
        }

        public string LatitudeLocation
        {
            get => _latitudeLocation;
            set
            {
                if (value != "N" && value != "S")
                {
                    throw new ArgumentException("Invalid location.");
                }
                _latitudeLocation = value;
            }
        }

        public string City
        {
            get => _city;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null");
                }
                _city = value;
            }
        }

        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance => _instance.Value;

        private Singleton() { }

        public string DetermineSeason()
        {
            if (LatitudeLocation == "N")
            {
                if (Date < 60 || Date > 334) return "Winter";
                if (Date < 152 && Date > 59) return "Spring";
                if (Date < 245 && Date > 151) return "Summer";
                if (Date < 335 && Date > 244) return "Autumn";
                return null;
            }
            else
            {
                if (Date < 60 || Date > 334) return "Summer";
                if (Date < 152 && Date > 59) return "Autumn";
                if (Date < 245 && Date > 151) return "Winter";
                if (Date < 335 && Date > 244) return "Spring";
                return null;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Singleton singleton &&
                   Date == singleton.Date &&
                   Latitude == singleton.Latitude &&
                   LatitudeLocation == singleton.LatitudeLocation &&
                   City == singleton.City;
        }

        public override int GetHashCode()
        {
            int hashCode = 351943582;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Latitude.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LatitudeLocation);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            return hashCode;
        }
    }
}
