using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> GetList()
        {
            return _aboutDal.GetList();
        }

        public void Insert(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}