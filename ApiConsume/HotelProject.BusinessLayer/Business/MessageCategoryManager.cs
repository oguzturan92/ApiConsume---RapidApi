using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Business
{
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;
        public MessageCategoryManager(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategoryDal = messageCategoryDal;
        }
        public void Delete(MessageCategory entity)
        {
            _messageCategoryDal.Delete(entity);
        }

        public MessageCategory GetById(int id)
        {
            return _messageCategoryDal.GetById(id);
        }

        public List<MessageCategory> GetList()
        {
            return _messageCategoryDal.GetList();
        }

        public void Insert(MessageCategory entity)
        {
            _messageCategoryDal.Insert(entity);
        }

        public void Update(MessageCategory entity)
        {
            _messageCategoryDal.Update(entity);
        }
    }
}