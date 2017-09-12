using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2BLL.BusinessObjects;
using ConsoleApp2DAL;
using ConsoleApp2BLL.Converters;
using System.Linq;

namespace ConsoleApp2BLL.Services
{
    class OrderService : IOrderService
    {
        OrderConverter conv = new OrderConverter();
        private DALFacade facade;
        public OrderService(DALFacade facade)
        {
            this.facade = facade;
        }

        public OrderBO Create(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Create(conv.Convert(order));
                uow.Complete();
                return conv.Convert(orderEntity);
            }
        }

        public List<OrderBO> CreateMultiple(List<OrderBO> orders)
        {
            throw new NotImplementedException();
        }

        public OrderBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Delete(id);
                uow.Complete();
                return conv.Convert(orderEntity);
            }
        }

        public List<OrderBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderRepository.GetAll().Select(conv.Convert).ToList(); ;
            }
        }

        public OrderBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(id);
                orderEntity.Customer = uow.CustomerRepository.GetCustomer(orderEntity.CustomerId);
                return conv.Convert(orderEntity);
            }
        }

        public OrderBO Update(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(order.Id);
                if (orderEntity == null)
                {
                    throw new InvalidOperationException("Order not found");
                }
                orderEntity.DeliveryDate = order.DeliveryDate;
                orderEntity.OrderDate = order.OrderDate;
                orderEntity.CustomerId = order.CustomerId;
                uow.Complete();
                orderEntity.Customer = uow.CustomerRepository.GetCustomer(orderEntity.CustomerId);
                return conv.Convert(orderEntity);
            }
        }
    }
}
