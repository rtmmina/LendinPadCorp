using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IInMemoryRepository<Order>
    {        
        IEnumerable<Order> GetOrders(Guid? userId = null, Guid? productId = null, DateTimeOffset? orderDate = null);
    }
}
