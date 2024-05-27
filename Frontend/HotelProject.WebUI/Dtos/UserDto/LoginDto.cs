using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.UserDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Zorunlu alan")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Password { get; set; }
    }
}