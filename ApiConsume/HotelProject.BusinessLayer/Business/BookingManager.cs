using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }
        public void Delete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking GetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> GetList()
        {
            return _bookingDal.GetList();
        }

        public void Insert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void Update(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}