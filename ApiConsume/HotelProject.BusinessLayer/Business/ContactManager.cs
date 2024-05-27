using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public int GetContactCount()
        {
            return _contactDal.GetContactCount();
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }

        public void Insert(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}