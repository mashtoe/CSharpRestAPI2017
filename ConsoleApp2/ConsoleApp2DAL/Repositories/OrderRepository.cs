using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2DAL.Entities;
using ConsoleApp2DAL.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2DAL.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        CustomerAppContext context;
        public OrderRepository(CustomerAppContext context)
        {
            this.context = context;
        }

        public Order Create(Order order)
        {
            context.Orders.Add(order);
            return order;
        }

        public Order Delete(int id)
        {
            var order = Get(id);
            context.Orders.Remove(order);
            return order;
        }

        public Order Get(int id)
        {
            return context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }
    }
}
