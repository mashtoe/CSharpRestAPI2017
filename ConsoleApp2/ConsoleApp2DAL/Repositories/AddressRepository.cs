using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2DAL.Entities;
using ConsoleApp2DAL.Context;
using System.Linq;

namespace ConsoleApp2DAL.Repositories
{
    internal class AddressRepository : IAddressRepository
    {
        CustomerAppContext context;
        public AddressRepository(CustomerAppContext context)
        {
            this.context = context;
        }

        public Address Create(Address address)
        {
            context.Addresses.Add(address);
            return address;
        }

        public Address Delete(int id)
        {
            var address = Get(id);
            context.Addresses.Remove(address);
            return address;
        }

        public Address Get(int id)
        {
            return context.Addresses.FirstOrDefault(o => o.Id == id);
        }

        public List<Address> GetAll()
        {
            return context.Addresses.ToList();
        }

        public IEnumerable<Address> GetAllById(List<int> ids)
        {
            if (ids == null)
            {
                return null;
            }

            return context.Addresses.Where(a => ids.Contains(a.Id));
        }
    }
}
