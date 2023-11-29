using RestaurantSignalRProject.DataAccessLayer.Abstract;
using RestaurantSignalRProject.DataAccessLayer.Concrate;
using RestaurantSignalRProject.DataAccessLayer.Repositories;
using RestaurantSignalRProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSignalRProject.DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : IGenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(RestaurantSignalRProjectContext context) : base(context)
        {
        }
    }
}
