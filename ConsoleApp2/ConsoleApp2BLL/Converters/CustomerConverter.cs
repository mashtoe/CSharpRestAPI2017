using ConsoleApp2BLL.BusinessObjects;
using ConsoleApp2DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2BLL.Converters
{
    class CustomerConverter
    {
        private AddressConverter aConv;

        public CustomerConverter()
        {
            aConv = new AddressConverter();
        }

        internal Customer Convert(CustomerBO cust)
        {
            if (cust == null)
            {
                return null;
            }
            return new Customer()
            {
                Id = cust.Id,

                Addresses = cust.AddressIds?.Select(aId => new CustomerAddress()
                {
                    AddressId = aId,
                    CustomerId = cust.Id
                }).ToList(),
                Name = cust.Name,
                Lastname = cust.Lastname
            };
        }

        internal CustomerBO Convert(Customer cust)
        {
            if (cust == null)
            {
                return null;
            }
            return new CustomerBO()
            {
                Id = cust.Id,
                AddressIds = cust.Addresses?.Select(a => a.AddressId).ToList(),
                Name = cust.Name,
                Lastname = cust.Lastname
            };
        }
    }
}
