using ConsoleApp2BLL.Services;
using ConsoleApp2DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2BLL
{
    public class BLLFacade
    {
        public ICustomerService CustomerService
        {
            get { return new CustomerService(new DALFacade()); }
        }

        public IOrderService OrderService
        {
            get { return new OrderService(new DALFacade()); }
        }
        public IAddressService AddressService
        {
            get { return new AddressService(new DALFacade()); }
        }
    }
}
