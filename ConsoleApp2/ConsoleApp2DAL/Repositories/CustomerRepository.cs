using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2DAL.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using ConsoleApp2DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerAppContext context;

        public CustomerRepository(CustomerAppContext context)
        {
            this.context = context;
        }

        public Customer Create(Customer cust)
        {
            context.Customers.Add(cust);
            return cust;
        }

        public bool DeleteCustomer(int id)
        {
            var cust = GetCustomer(id);
            context.Customers.Remove(cust);
            return true;
        }

        public List<Customer> GetAll()
        {
            return context.Customers
                .Include(c => c.Addresses)
                .ToList();
        }

        public Customer GetCustomer(int id)
        {
            return context.Customers.Include(c => c.Addresses).FirstOrDefault(x => x.Id == id);
        }
    }
}
