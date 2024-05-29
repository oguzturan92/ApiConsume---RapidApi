using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.BookingDto
{
    public class BookingListDto
    {
        public int BookingId { get; set; }
        public string BookingName { get; set; }
        public string BookingMail { get; set; }
        public DateTime BookingCheckin { get; set; }
        public DateTime BookingCheckout { get; set; }
        public string BookingAdultCount { get; set; }
        public string BookingChildCount { get; set; }
        public string BookingRoomCount { get; set; }
        public string BookingSpecialRequest { get; set; }
        public string BookingDescription { get; set; }
        public string BookingCountry { get; set; }
        public string BookingCity { get; set; }
        public string BookingStatus { get; set; }
    }
}