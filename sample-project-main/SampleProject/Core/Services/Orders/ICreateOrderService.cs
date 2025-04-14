using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, Guid userId, Guid productId, float quantity, decimal totalAmount, DateTimeOffset orderDate);
    }
}
