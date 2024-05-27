using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class ServiceUpdateDto
    {
        [Required(ErrorMessage = "Zorunlu alan")]
        public int ServiceId { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    }
}