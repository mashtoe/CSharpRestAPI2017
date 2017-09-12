﻿using ConsoleApp2BLL.BusinessObjects;
using ConsoleApp2DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2BLL.Converters
{
    class CustomerConverter
    {
        internal Customer Convert(CustomerBO cust)
        {
            if (cust == null)
            {
                return null;
            }
            return new Customer()
            {
                Id = cust.Id,
                Address = cust.Address,
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
                Address = cust.Address,
                Name = cust.Name,
                Lastname = cust.Lastname
            };
        }
    }
}
