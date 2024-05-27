using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public List<AppUser> UserListAndWorkLocation()
        {
            using (var context = new Context())
            {
                return context.Users
                            .Include(i => i.WorkLocation)
                            .Select(i => new AppUser()
                            {
                                Id = i.Id,
                                UserName = i.UserName,
                                Name = i.Name,
                                Surname = i.Surname,
                                City = i.City,
                                Department = i.WorkLocation.WorkLocationName,
                                WorkLocationId = i.WorkLocationId
                            })
                            .ToList();
            }
        }
    }
}