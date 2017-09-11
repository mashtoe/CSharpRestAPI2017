
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

        public CustomerAppContext() : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
