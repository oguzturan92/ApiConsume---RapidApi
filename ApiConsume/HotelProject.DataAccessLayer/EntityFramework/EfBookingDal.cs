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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public int GetBookingCount()
        {
            using (var context = new Context())
            {
                return context.Bookings.Count();
            }
        }

        public List<Booking> Last6Booking()
        {
            using (var context = new Context())
            {
                return context.Bookings.OrderByDescending(i => i.BookingId).Take(6).ToList();
            }
        }
    }
}