using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomCreateDto
    {
        // [Required(ErrorMessage = "Zorunlu alan.")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public int RoomPrice { get; set; }
        public string RoomTitle { get; set; }
        public string RoomBedCount { get; set; }
        public string RoomBathCount { get; set; }
        public string RoomWifiCount { get; set; }
        public string RoomDescription { get; set; }
    }
}