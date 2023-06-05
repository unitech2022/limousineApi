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

         public DbSet<Address>? Addresses { get; set; }

        public DbSet<Group>? Groups { get; set; }

        public DbSet<GroupLocation>? GroupLocations { get; set; }

         public DbSet<City> Cities { get; set; }

         public DbSet<ExternalTrip>? ExternalTrips { get; set; }

      public DbSet<Booking>? Bookings { get; set; }

        // public DbSet<ProductsOption>? ProductsOptions { get; set; }

        //  public DbSet<Market>? Markets { get; set; }

         public DbSet<Rate>? Rates { get; set; }

        //  public DbSet<Coupon>? Coupons { get; set; }
    
    
    
    }
}