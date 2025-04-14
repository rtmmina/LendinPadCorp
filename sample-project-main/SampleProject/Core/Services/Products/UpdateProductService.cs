using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    //[AutoRegister(AutoRegisterTypes.Singleton)]
    [AutoRegister]
    public class UpdateProductService : IUpdateProductService
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Update(Product product, string name, string description, string category, decimal price)
        {
            AssignUpdateProperties(product, name, description, category, price);
            _productRepository.Update(product);
        }

        private static void AssignUpdateProperties(Product product, string name, string description, string category, decimal price)
        {
            product.SetName(name);
            product.SetDescription(description);
            product.SetCategory(category);
            product.SetPrice(price);
        }
    }
}
