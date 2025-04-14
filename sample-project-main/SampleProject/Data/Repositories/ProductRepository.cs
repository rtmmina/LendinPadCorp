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
    public class ProductRepository : InMemoryRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _cache;

        public ProductRepository(AppDbContext cache) : base(cache) 
        {
            _cache = cache;
        }


        public IEnumerable<Product> GetProducts(string name = null, string description = null, string category = null)
        {
            var products = _cache.Set<Product>().ToList();
            

            var filteredProductsByName = products
                .Where(p => name is null || p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            var filteredProductsByDescription = filteredProductsByName.Where(p => description is null || p.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            var filteredProductsByCategory = filteredProductsByDescription.Where(p => category is null || p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));


            return filteredProductsByCategory;
        }
    }
}
