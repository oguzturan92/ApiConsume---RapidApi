using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.UserDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Zorunlu alan")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string RePassword { get; set; }
    }
}