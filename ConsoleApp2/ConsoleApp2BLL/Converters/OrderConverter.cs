using ConsoleApp2BLL.BusinessObjects;
using ConsoleApp2DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2BLL.Converters
{
    class OrderConverter
    {
        internal Order Convert(OrderBO order)
        {
            return new Order()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate
            };
        }

        internal OrderBO Convert(Order order)
        {
            return new OrderBO()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.DeliveryDate
            };
        }
    }
}
