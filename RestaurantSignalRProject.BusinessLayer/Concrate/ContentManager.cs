using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DataAccessLayer.Abstract;
using RestaurantSignalRProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSignalRProject.BusinessLayer.Concrate
{
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void TAdd(Content entity)
        {
            _contentDal.Add(entity);
        }

        public void TDelete(Content entity)
        {
            _contentDal.Delete(entity);
        }

        public Content TGetById(int id)
        {
           return _contentDal.GetByID(id);
        }

        public List<Content> TGetListAll()
        {
            return _contentDal.GetListAll();
        }

        public void TUpdate(Content entity)
        {
           _contentDal.Update(entity);
        }
    }
}
