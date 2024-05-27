using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    }
}