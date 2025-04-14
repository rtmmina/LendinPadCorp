using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IUpdateProductService _updateProductService;        
        private readonly IIdObjectFactory<Product> _productFactory;
        private readonly IProductRepository _productRepository;

        public CreateProductService(IIdObjectFactory<Product> productFactory, IUpdateProductService updateProductService, IProductRepository productRepository)
        {
            _productFactory = productFactory;
            _updateProductService = updateProductService;
            _productRepository = productRepository;
        }
        public Product Create(Guid id, string name, string description, string category, decimal price)
        {
            var productInDb = _productRepository.Get(id);
            if (productInDb != null)
            {
                _updateProductService.Update(productInDb, name, description, category, price);
                _productRepository.Create(productInDb);
                return productInDb;
            }
            else
            {
                var product = _productFactory.Create(id);
                AssignUpdateProperties(product, name, description, category, price);
                _productRepository.Create(product);
                return product;
            }
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
