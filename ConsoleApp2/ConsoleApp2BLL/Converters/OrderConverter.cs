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
            if (order == null)
            {
                return null;
            }
            return new Order()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId
            };
        }

        internal OrderBO Convert(Order order)
        {
            if (order == null)
            {
                return null;
            }
            return new OrderBO()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.DeliveryDate,
                Customer = new CustomerConverter().Convert(order.Customer),
                CustomerId = order.CustomerId
            };
        }
    }
}
