using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public UpdateOrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
        public void Update(Order Order, float quantity, decimal totalAmount, DateTimeOffset orderDate)
        {
            AssignUpdateProperties(Order, quantity, totalAmount, orderDate);
            _OrderRepository.Update(Order);
        }

        private static void AssignUpdateProperties(Order Order, float quantity, decimal totalAmount, DateTimeOffset orderDate)
        {
            Order.SetQuantity(quantity);
            Order.SetTotalAmount(totalAmount);
            Order.SetOrderDate(orderDate);            
        }
    }
}
