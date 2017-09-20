using ConsoleApp2DAL.Context;
using ConsoleApp2DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; internal set; }
        //public IGenreRepository GenreRepository { get; internal set; }

        public IOrderRepository OrderRepository { get; internal set; }

        public IAddressRepository AddressRepository { get; internal set; }

        private CustomerAppContext context;

        public UnitOfWork()
        {
            context = new CustomerAppContext();
            context.Database.EnsureCreated();
            CustomerRepository = new CustomerRepository(context);
            OrderRepository = new OrderRepository(context);
            AddressRepository = new AddressRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }                                                                       
}
