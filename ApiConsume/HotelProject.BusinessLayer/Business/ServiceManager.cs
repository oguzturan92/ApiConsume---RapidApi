using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }
        public void Delete(Service entity)
        {
            _serviceDal.Delete(entity);
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(id);
        }

        public List<Service> GetList()
        {
            return _serviceDal.GetList();
        }

        public void Insert(Service entity)
        {
            _serviceDal.Insert(entity);
        }

        public void Update(Service entity)
        {
            _serviceDal.Update(entity);
        }
    }
}