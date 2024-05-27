using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffTitle { get; set; }
        public string StaffImage { get; set; }
        public string StaffSocialMedia1 { get; set; }
        public string StaffSocialMedia2 { get; set; }
        public string StaffSocialMedia3 { get; set; }
    }
}