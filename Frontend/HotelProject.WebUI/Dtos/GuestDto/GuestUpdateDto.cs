using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.GuestDto
{
    public class GuestUpdateDto
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestSurname { get; set; }
        public string GuestCity { get; set; }
    }
}