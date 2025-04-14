using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order Order, float quantity, decimal totalAmount, DateTimeOffset orderDate);
    }
}
