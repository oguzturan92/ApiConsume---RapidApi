using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public int AppUserCount()
        {
            return _appUserDal.AppUserCount();
        }

        public void Delete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public AppUser GetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> GetList()
        {
            return _appUserDal.GetList();
        }

        public void Insert(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void Update(AppUser entity)
        {
            _appUserDal.Update(entity);
        }

        public List<AppUser> UserListAndWorkLocation()
        {
            return _appUserDal.UserListAndWorkLocation();
        }
    }
}