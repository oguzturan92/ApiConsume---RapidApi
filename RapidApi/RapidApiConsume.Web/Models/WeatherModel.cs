using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApiConsume.Web.Models
{
    public class WeatherModel
    {
        public Location location { get; set; }
        public Forecasts[] forecasts { get; set; }
        public class Location
        {
            public string city { get; set; }
            public string country { get; set; }
        }
        public class Forecasts
        {
            public string day { get; set; }
            public string text { get; set; }
        }
    }
}