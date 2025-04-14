using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IProductRepository : IInMemoryRepository<Product>
    {        
        IEnumerable<Product> GetProducts(string name = null, string description = null, string category = null);
    }
}
