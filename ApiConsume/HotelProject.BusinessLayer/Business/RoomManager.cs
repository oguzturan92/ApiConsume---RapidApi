using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;
        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }
        public void Delete(Room entity)
        {
            _roomDal.Delete(entity);
        }

        public Room GetById(int id)
        {
            return _roomDal.GetById(id);
        }

        public List<Room> GetList()
        {
            return _roomDal.GetList();
        }

        public void Insert(Room entity)
        {
            _roomDal.Insert(entity);
        }

        public int RoomCount()
        {
            return _roomDal.RoomCount();
        }

        public void Update(Room entity)
        {
            _roomDal.Update(entity);
        }
    }
}