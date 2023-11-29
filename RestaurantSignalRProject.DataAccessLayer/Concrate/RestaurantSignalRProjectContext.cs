using Microsoft.EntityFrameworkCore;
using RestaurantSignalRProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSignalRProject.DataAccessLayer.Concrate
{
    public class RestaurantSignalRProjectContext:DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RestaurantSignalRDb;Trusted_Connection=True;");
        }

    }
}
