using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private float _quantity;
        private decimal _totalAmount;
        private DateTimeOffset _orderDate;

        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public float Quantity
        {
            get => _quantity;
            private set => _quantity = value;
        }

        public decimal TotalAmount
        {
            get => _totalAmount;
            private set => _totalAmount = value;
        }
        public DateTimeOffset OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }

        public void SetQuantity(float quantity)
        {
            if (quantity <= 0)
                throw new Exception("Quantity was not provided.");
            _quantity = quantity;
        }

        public void SetTotalAmount(decimal totalAmount)
        {
            if (totalAmount <= 0)
                throw new Exception("Total Amount was not provided.");
            _totalAmount = totalAmount;
        }

        public void SetOrderDate(DateTimeOffset orderDate)
        {
            if (orderDate == DateTimeOffset.MinValue)
                throw new Exception("Order Date was not provided.");
            _orderDate = orderDate;
        }
    }
}
