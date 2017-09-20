using ConsoleApp2BLL.BusinessObjects;
using ConsoleApp2BLL.Converters;
using ConsoleApp2DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2BLL.Services
{
    class AddressService : IAddressService
    {
        DALFacade facade;
        AddressConverter conv = new AddressConverter();

        public AddressService(DALFacade facade)
        {
            this.facade = facade;
        }

        //public AddressBO Create(AddressBO address)
        //{
        //    using (var uow = facade.UnitOfWork)
        //    {
        //        var newAddress = uow.AddressRepository.Create(conv.Convert(address));
        //        uow.Complete();
        //        return conv.Convert(newAddress);
        //    }
        //}

        public AddressBO Create(AddressBO address)
        {
            using (var uow = facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Create(conv.Convert(address));
                uow.Complete();
                return conv.Convert(addressEntity);
            }
        }

        //public List<AddressBO> CreateMultiple(List<AddressBO> customers)
        //{
        //    using (var uow = facade.UnitOfWork)
        //    {
        //        List<CustomerBO> retrunListCust = new List<CustomerBO>();
        //        for (int i = 0; i < customers.Count; i++)
        //        {
        //            var newCust = uow.CustomerRepository.Create(conv.Convert(customers[i]));
        //            retrunListCust.Add(conv.Convert(newCust));
        //        }
        //        uow.Complete();
        //        return retrunListCust;
        //    }
        //}

        public AddressBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var address = uow.AddressRepository.Delete(id);
                uow.Complete();
                return conv.Convert(address);
            }
        }

        public List<AddressBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Customer -> CustomerBO
                //return uow.CustomerRepository.GetAll();
                return uow.AddressRepository.GetAll().Select(c => conv.Convert(c)).ToList();
            }
        }

        public AddressBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.AddressRepository.Get(id));
            }
        }

        public AddressBO Update(AddressBO address)
        {
            using (var uow = facade.UnitOfWork)
            {
                var addressFromDb = uow.AddressRepository.Get(address.Id);
                if (addressFromDb == null)
                {
                    throw new InvalidOperationException("Address not found");
                }
                addressFromDb.City = address.City;
                addressFromDb.Number = address.Number;
                addressFromDb.Street = address.Street;

                uow.Complete();
                return conv.Convert(addressFromDb);
            }
        }
    }
}
