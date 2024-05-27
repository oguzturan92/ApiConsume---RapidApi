using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class MessageCategory
    {
        public int MessageCategoryId { get; set; }
        public string MessageCategoryTitle { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}