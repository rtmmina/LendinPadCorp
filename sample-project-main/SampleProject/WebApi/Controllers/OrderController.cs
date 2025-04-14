using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Orders;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{OrderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid OrderId, [FromBody] OrderModel model)
        {
            var Order = _createOrderService.Create(OrderId, model.UserId, model.ProductId, model.Quantity, model.TotalAmount, model.OrderDate);
            var prod = new OrderData(Order);
            return Found(prod);
        }

        [Route("{OrderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid OrderId, [FromBody] OrderModel model)
        {
            var Order = _getOrderService.GetOrder(OrderId);
            if (Order == null)
            {
                return DoesNotExist();
            }
            _updateOrderService.Update(Order, model.Quantity, model.TotalAmount, model.OrderDate);
            return Found(new OrderData(Order));
        }

        [Route("{OrderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid OrderId)
        {
            var Order = _getOrderService.GetOrder(OrderId);
            if (Order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(Order);
            return Found();
        }

        [Route("{OrderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid OrderId)
        {
            var Order = _getOrderService.GetOrder(OrderId);
            if (Order == null)
            {
                return DoesNotExist();
            }
            return Found(new OrderData(Order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take, Guid? userId = null, Guid? productId = null, DateTimeOffset? orderDate = null)
        {
            var Orders = _getOrderService.GetOrders(userId, productId, orderDate)
                                       .Skip(skip).Take(take)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(Orders);
        }

    }
}