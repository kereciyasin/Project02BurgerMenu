using Project02BurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project02BurgerMenu.Content
{
    public class BurgerMenu01Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<DealOfTheDay> DealOfTheDays { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}