using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Models
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}