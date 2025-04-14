using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface ICreateProductService
    {
        Product Create(Guid id, string name, string description, string category, decimal price);
    }
}
