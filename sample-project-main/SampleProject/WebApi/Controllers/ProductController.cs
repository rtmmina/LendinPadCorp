using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Products;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductController(ICreateProductService createProductService, IDeleteProductService deleteProductService, IGetProductService getProductService, IUpdateProductService updateProductService)
        {
            _createProductService = createProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
        }

        [Route("{ProductId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid ProductId, [FromBody] ProductModel model)
        {
            var Product = _createProductService.Create(ProductId, model.Name, model.Description, model.Category, model.Price);
            var prod = new ProductData(Product);
            return Found(prod);
        }

        [Route("{ProductId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid ProductId, [FromBody] ProductModel model)
        {
            var Product = _getProductService.GetProduct(ProductId);
            if (Product == null)
            {
                return DoesNotExist();
            }
            _updateProductService.Update(Product, model.Name, model.Description, model.Category, model.Price);
            return Found(new ProductData(Product));
        }

        [Route("{ProductId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid ProductId)
        {
            var Product = _getProductService.GetProduct(ProductId);
            if (Product == null)
            {
                return DoesNotExist();
            }
            _deleteProductService.Delete(Product);
            return Found();
        }

        [Route("{ProductId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid ProductId)
        {
            var Product = _getProductService.GetProduct(ProductId);
            if (Product == null)
            {
                return DoesNotExist();
            }
            return Found(new ProductData(Product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts(int skip, int take, string name = null, string description = null, string category = null)
        {
            var Products = _getProductService.GetProducts(name, description, category)
                                       .Skip(skip).Take(take)
                                       .Select(q => new ProductData(q))
                                       .ToList();
            return Found(Products);
        }

    }
}