using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Entities
{
    public interface IApplicationDBContext
    {
     

        public  DbSet<Address> Addresses { get; set; }

        public  DbSet<Attachment> Attachments { get; set; }

        public  DbSet<Brand> Brands { get; set; }

        public  DbSet<Category> Categories { get; set; }

        public  DbSet<Order> Orders { get; set; }

        public  DbSet<OrderItem> OrderItems { get; set; }

        public  DbSet<Parameter> Parameters { get; set; }

        public  DbSet<ParameterType> ParameterTypes { get; set; }

        public  DbSet<Payment> Payments { get; set; }

        public  DbSet<Product> Products { get; set; }

        public  DbSet<ProductImage> ProductImages { get; set; }

        public  DbSet<RedirectLink> RedirectLinks { get; set; }

        public  DbSet<Review> Reviews { get; set; }

        public  DbSet<Role> Roles { get; set; }

        public  DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
