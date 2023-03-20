using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace LimousineApi.Data
{
    public class AppDBcontext : IdentityDbContext<User>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {


            
        }
       public DbSet<Driver>? Drivers { get; set; }

    

         public DbSet<CarType>? CarTypes { get; set; }

        public DbSet<Trip>? Trips { get; set; }

        public DbSet<Notification>? Notifications { get; set; }

        // public DbSet<Field>? Fields { get; set; }

        // public DbSet<Offer>? Offers { get; set; }

        // public DbSet<Order>? Orders { get; set; }

        // public DbSet<OrderItem>? OrderItems { get; set; }

        // public DbSet<OrderItemOption>? OrderItemOptions { get; set; }

        // public DbSet<Product>? Products { get; set; }

        // public DbSet<ProductsOption>? ProductsOptions { get; set; }

        //  public DbSet<Market>? Markets { get; set; }

        //   public DbSet<Rate>? Rates { get; set; }

        //  public DbSet<Coupon>? Coupons { get; set; }
    
    
    
    }
}