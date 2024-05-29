using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public int GetStaffCount()
        {
            using (var context = new Context())
            {
                return context.Staff.Count();
            }
        }

        public List<Staff> GetStaffLast4()
        {
            using (var context = new Context())
            {
                return context.Staff.OrderByDescending(i => i.StaffId).Take(4).ToList();
            }
        }
    }
}