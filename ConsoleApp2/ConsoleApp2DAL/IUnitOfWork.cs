using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2DAL
{
    public interface IUnitOfWork : IDisposable
    {   
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IAddressRepository AddressRepository { get; }

        //genre??


        int Complete();
    }
}
