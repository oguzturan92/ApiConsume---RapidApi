using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.ServiceDto
{
    public class ServiceCreateDto
    {
        public string ServiceIcon { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    }
}