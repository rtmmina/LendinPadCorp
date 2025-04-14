using BusinessEntities;
using System;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order Order) : base(Order)
        {
            UserId = Order.UserId;
            ProductId = Order.ProductId;
            Quantity = Order.Quantity;
            TotalAmount = Order.TotalAmount;
            OrderDate = Order.OrderDate;
        }

        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public float Quantity { get; set; }
        public decimal TotalAmount { get; set; }      
        public DateTimeOffset OrderDate { get; set; }
    }
}