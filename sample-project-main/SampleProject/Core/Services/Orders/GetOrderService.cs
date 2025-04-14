using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public GetOrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public Order GetOrder(Guid id)
        {
            return _OrderRepository.Get(id);
        }

        public IEnumerable<Order> GetOrders(Guid? userId, Guid? productId, DateTimeOffset? orderDate)
        {
            return _OrderRepository.GetOrders(userId, productId, orderDate);
        }
    }
}
