using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.StaffDto
{
    public class StaffUpdateDto
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