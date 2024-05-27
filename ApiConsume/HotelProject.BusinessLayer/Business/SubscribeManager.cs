using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;
        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }
        public void Delete(Subscribe entity)
        {
            _subscribeDal.Delete(entity);
        }

        public Subscribe GetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public List<Subscribe> GetList()
        {
            return _subscribeDal.GetList();
        }

        public void Insert(Subscribe entity)
        {
            _subscribeDal.Insert(entity);
        }

        public void Update(Subscribe entity)
        {
            _subscribeDal.Update(entity);
        }
    }
}