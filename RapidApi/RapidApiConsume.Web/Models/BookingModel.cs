using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApiConsume.Web.Models
{
    public class BookingModel
    {
        public Data[] data { get; set; }
        public class Data
        {
            public string name { get; set; }
            public float reviewScore { get; set; }
        }
        public bool status { get; set; }
        public string message { get; set; }
    }
    
}