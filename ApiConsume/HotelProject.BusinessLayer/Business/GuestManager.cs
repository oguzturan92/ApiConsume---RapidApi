using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;
        public GuestManager(IGuestDal guestDal)
        {
            _guestDal = guestDal;
        }
        public void Delete(Guest entity)
        {
            _guestDal.Delete(entity);
        }

        public Guest GetById(int id)
        {
            return _guestDal.GetById(id);
        }

        public List<Guest> GetList()
        {
            return _guestDal.GetList();
        }

        public void Insert(Guest entity)
        {
            _guestDal.Insert(entity);
        }

        public void Update(Guest entity)
        {
            _guestDal.Update(entity);
        }
    }
}