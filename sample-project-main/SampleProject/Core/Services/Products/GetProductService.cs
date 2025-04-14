using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetProducts(string name = null, string description = null, string category = null)
        {
            return _productRepository.GetProducts(name, description, category);
        }
    }
}
