using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.ContactDto
{
    public class ContactCreateDto
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
    }
}