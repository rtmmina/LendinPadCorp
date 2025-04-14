using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);
        IEnumerable<Order> GetOrders(Guid? userId, Guid? productId, DateTimeOffset? orderDate);
    }
}
