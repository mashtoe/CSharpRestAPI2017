using ConsoleApp2DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2DAL
{
    public interface IAddressRepository
    {
        //C
        Address Create(Address address);
        //R
        List<Address> GetAll();
        IEnumerable<Address> GetAllById(List<int> ids);
        Address Get(int id);
        //U No update for the Repository, It will be the task of the unit of work
        //D
        Address Delete(int id);
    }
}
