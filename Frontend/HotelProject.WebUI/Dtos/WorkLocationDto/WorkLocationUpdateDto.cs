using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.AboutDto
{
    public class WorkLocationUpdateDto
    {
        public int WorkLocationId { get; set; }
        public string WorkLocationName { get; set; }
        public string WorkLocationCity { get; set; }
    }
}