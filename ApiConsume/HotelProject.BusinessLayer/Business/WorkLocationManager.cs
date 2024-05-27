using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;
        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }
        public void Delete(WorkLocation entity)
        {
            _workLocationDal.Delete(entity);
        }

        public WorkLocation GetById(int id)
        {
            return _workLocationDal.GetById(id);
        }

        public List<WorkLocation> GetList()
        {
            return _workLocationDal.GetList();
        }

        public void Insert(WorkLocation entity)
        {
            _workLocationDal.Insert(entity);
        }

        public void Update(WorkLocation entity)
        {
            _workLocationDal.Update(entity);
        }
    }
}