using ConsoleApp2DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2DAL
{
    public interface IOrderRepository
    {
        //C
        Order Create(Order cust);
        //R
        List<Order> GetAll();
        Order Get(int id);
        //U No update for the Repository, It will be the task of the unit of work
        //D
        Order Delete(int id);
    }
}
