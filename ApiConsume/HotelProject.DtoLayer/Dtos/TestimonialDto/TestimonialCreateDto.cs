using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.TestimonialDto
{
    public class TestimonialCreateDto
    {
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialDescription { get; set; }
        public string TestimonialImage { get; set; }
    }
}