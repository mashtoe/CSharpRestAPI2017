using ConsoleApp2BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2BLL
{
    public interface IOrderService
    {
        //C
        OrderBO Create(OrderBO order);
        //R
        List<OrderBO> GetAll();
        OrderBO Get(int id);
        //U
        OrderBO Update(OrderBO order);
        //D
        OrderBO Delete(int id);

        List<OrderBO> CreateMultiple(List<OrderBO> orders);
    }
}
