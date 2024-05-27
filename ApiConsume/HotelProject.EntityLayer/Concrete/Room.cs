using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public int RoomPrice { get; set; }
        public string RoomTitle { get; set; }
        public string RoomBedCount { get; set; }
        public string RoomBathCount { get; set; }
        public string RoomDescription { get; set; }
    }
}