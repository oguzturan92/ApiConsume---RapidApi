using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;
        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }
        public void Delete(Staff entity)
        {
            _staffDal.Delete(entity);
        }

        public Staff GetById(int id)
        {
            return _staffDal.GetById(id);
        }

        public List<Staff> GetList()
        {
            return _staffDal.GetList();
        }

        public void Insert(Staff entity)
        {
            _staffDal.Insert(entity);
        }

        public void Update(Staff entity)
        {
            _staffDal.Update(entity);
        }
    }
}