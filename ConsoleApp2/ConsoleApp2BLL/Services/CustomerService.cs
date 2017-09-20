using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2DAL;
using System.Linq;
using ConsoleApp2BLL.BusinessObjects;
using ConsoleApp2DAL.Entities;
using ConsoleApp2BLL.Converters;

namespace ConsoleApp2BLL.Services
{
    class CustomerService : ICustomerService
    {
        DALFacade facade;
        CustomerConverter conv = new CustomerConverter();
        AddressConverter aConv = new AddressConverter();

        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();
                return conv.Convert(newCust);
            }
        }

        public List<CustomerBO> CreateMultiple(List<CustomerBO> customers)
        {
            using (var uow = facade.UnitOfWork)
            {
                List<CustomerBO> retrunListCust = new List<CustomerBO>();
                for (int i = 0; i < customers.Count; i++)
                {
                    var newCust = uow.CustomerRepository.Create(conv.Convert(customers[i]));
                    retrunListCust.Add(conv.Convert(newCust));
                }
                uow.Complete();
                return retrunListCust;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var succeeded = uow.CustomerRepository.DeleteCustomer(id);
                uow.Complete();
                return succeeded;
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Customer -> CustomerBO
                //return uow.CustomerRepository.GetAll();
                return uow.CustomerRepository.GetAll().Select(c => conv.Convert(c)).ToList();
            }
        }

        public CustomerBO GetCustomer(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var cust = conv.Convert(uow.CustomerRepository.GetCustomer(Id));
                /*
                cust.Addresses = cust.AddressIds?
                    .Select(id => aConv.Convert(uow.AddressRepository.Get(id)))
                    .ToList();*/

                cust.Addresses = uow.AddressRepository.GetAllById(cust.AddressIds)
                    .Select(a => aConv.Convert(a))
                    .ToList();
                return cust;
            }
        }

        public CustomerBO UpdateCustomer(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.GetCustomer(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                var customerUpdated = conv.Convert(cust);
                customerFromDb.Name = customerUpdated.Name;
                customerFromDb.Lastname = customerUpdated.Lastname;
                customerFromDb.Addresses.RemoveAll(
                    ca => !customerUpdated.Addresses.Exists(
                    a => a.AddressId == ca.AddressId &&
                    a.CustomerId == ca.CustomerId));

                customerUpdated.Addresses.RemoveAll(
                    ca => customerFromDb.Addresses.Exists(
                        a => a.AddressId == ca.AddressId &&
                    a.CustomerId == ca.CustomerId));


                customerFromDb.Addresses.AddRange(
                    customerUpdated.Addresses
                    );

                uow.Complete(); 
                return conv.Convert(customerFromDb);
            }
        }


        //private Customer Convert(CustomerBO cust)
        //{
        //    return new Customer()
        //    {
        //        Id = cust.Id,
        //        Address = cust.Address,
        //        Name = cust.Name,
        //        Lastname = cust.Lastname
        //    };
        //}

        //private CustomerBO Convert(Customer cust)
        //{
        //    return new CustomerBO()
        //    {
        //        Id = cust.Id,
        //        Address = cust.Address,
        //        Name = cust.Name,
        //        Lastname = cust.Lastname
        //    };
        //}
    }
}
