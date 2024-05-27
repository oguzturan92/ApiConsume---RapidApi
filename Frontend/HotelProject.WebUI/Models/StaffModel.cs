using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Models
{
    public class StaffListModel
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffTitle { get; set; }
        public string StaffImage { get; set; }
    }

    public class StaffCreateModel
    {
        public string StaffName { get; set; }
        public string StaffTitle { get; set; }
        public string StaffImage { get; set; }
        public string StaffSocialMedia1 { get; set; }
        public string StaffSocialMedia2 { get; set; }
        public string StaffSocialMedia3 { get; set; }
    }

    public class StaffUpdateModel
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