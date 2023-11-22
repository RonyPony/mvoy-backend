using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using mvoy.core.Models;

namespace mvoy.data.DataContext
{
    public partial class MvoyContext : DbContext
    {

        public MvoyContext(DbContextOptions<MvoyContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //if (!optionsBuilder.IsConfigured)
        //    //{
        //    //    optionsBuilder.UseSqlServer(cnnstr);
        //    //}
        //}

        public DbSet<User> users { get; set; }
        public DbSet<UserContactInfo> usersContactInfo { get; set; }
        public DbSet<Trip> trips { get; set; }
         public DbSet<Offer> offers { get; set; }

        public DbSet<Vehicle> vehicles { get; set; }
    }
}
