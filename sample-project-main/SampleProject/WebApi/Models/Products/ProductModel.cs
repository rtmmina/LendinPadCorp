using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Users
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}