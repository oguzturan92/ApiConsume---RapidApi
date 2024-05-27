using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class ContactCreateDto
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
        public int MessageCategoryId { get; set; }
    }
}