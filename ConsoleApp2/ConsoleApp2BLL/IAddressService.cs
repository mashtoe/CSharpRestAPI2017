﻿using ConsoleApp2BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2BLL
{
    public interface IAddressService
    {
        //C
        AddressBO Create(AddressBO address);
        //R
        List<AddressBO> GetAll();
        AddressBO Get(int id);
        //U
        AddressBO Update(AddressBO address);
        //D
        AddressBO Delete(int id);

        //List<AddressBO> CreateMultiple(List<AddressBO> orders);
    }
}
