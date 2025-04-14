using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;        
        private readonly IIdObjectFactory<Order> _OrderFactory;
        private readonly IOrderRepository _OrderRepository;

        public CreateOrderService(IIdObjectFactory<Order> OrderFactory, IUpdateOrderService updateOrderService, IOrderRepository OrderRepository)
        {
            _OrderFactory = OrderFactory;
            _updateOrderService = updateOrderService;
            _OrderRepository = OrderRepository;
        }
        public Order Create(Guid id, Guid userId, Guid productId, float quantity, decimal totalAmount, DateTimeOffset orderDate)
        {
            var OrderInDb = _OrderRepository.Get(id);
            if (OrderInDb != null)
            {
                _updateOrderService.Update(OrderInDb, quantity, totalAmount, orderDate);
                _OrderRepository.Create(OrderInDb);
                return OrderInDb;
            }
            else
            {
                var Order = _OrderFactory.Create(id);
                AssignUpdateProperties(Order, userId, productId, quantity, totalAmount, orderDate);
                _OrderRepository.Create(Order);
                return Order;
            }
        }

        private static void AssignUpdateProperties(Order Order, Guid userId, Guid productId, float quantity, decimal totalAmount, DateTimeOffset orderDate)
        {
            Order.SetQuantity(quantity);
            Order.SetTotalAmount(totalAmount);
            Order.SetOrderDate(orderDate);
            Order.UserId = userId;
            Order.ProductId = productId;
        }
    }
}
