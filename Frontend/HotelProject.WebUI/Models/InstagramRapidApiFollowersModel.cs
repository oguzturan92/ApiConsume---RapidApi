using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Models
{
    public class InstagramRapidApiFollowersModel
    {
        public Data data { get; set; }
        public class Data
        {
            public int total { get; set; }
        }
        
    }


}