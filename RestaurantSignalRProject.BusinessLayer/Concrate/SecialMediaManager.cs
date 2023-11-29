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
    public class SecialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SecialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaDal.GetByID(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMediaDal.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
