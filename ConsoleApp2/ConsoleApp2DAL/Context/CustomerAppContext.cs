
using ConsoleApp2DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2DAL.Context
{
    public class CustomerAppContext : DbContext
    {
        static DbContextOptions<CustomerAppContext> options = 
            new DbContextOptionsBuilder<CustomerAppContext>().UseInMemoryDatabase("TheDB").Options;

        private string localfolder = @"C:\Mineting\Programfiler\RESTAPICRUDAPP\phrase.txt";
        /*
        public CustomerAppContext() : base(options)
        {

        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string text = System.IO.File.ReadAllText(localfolder);
                optionsBuilder.UseSqlServer($@"Server=tcp:mashtoes-server.database.windows.net,1433;Initial Catalog=CS2017;Persist Security Info=False;User ID=mashtoe;Password={text};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new { ca.AddressId,ca.CustomerId});

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(ca => ca.AddressId);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(ca => ca.CustomerId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Addresses { get; set;  }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
