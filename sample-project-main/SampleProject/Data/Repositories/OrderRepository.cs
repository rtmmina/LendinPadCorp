using Common;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using Raven.Client;
using Data.Indexes;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : InMemoryRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _cache;

        public OrderRepository(AppDbContext cache) : base(cache) 
        {
            _cache = cache;
        }


        public IEnumerable<Order> GetOrders(Guid? userId = null, Guid? productId = null, DateTimeOffset? orderDate = null)
        {
            var Orders = _cache.Set<Order>().ToList();
            

            var filteredOrdersByUserId = Orders
                .Where(p => userId is null || p.UserId == userId);
            var filteredOrdersByProductId = filteredOrdersByUserId.Where(p => productId is null || p.ProductId == productId);
            var filteredOrdersByOrderDate = filteredOrdersByProductId.Where(p => orderDate is null || p.OrderDate.Date.Equals(orderDate.Value.Date));


            return filteredOrdersByOrderDate;
        }
    }
}
