using System;
using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public float Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset OrderDate { get; set; }
    }
}