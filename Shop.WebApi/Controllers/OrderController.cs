using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Microsoft.Extensions.Logging;
using DtoEntities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        // GET: api/product
        [HttpGet]
        public JsonResult Get()
        {
            logger.LogWarning("Hi!");
            logger.LogInformation(";)");
            return Json(orderService.getOrders());
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(orderService.getOrder(id));
        }

        // POST api/product
        [HttpPost]
        public JsonResult Post([FromBody]OrderDTO order)
        {
            return Json(orderService.addOrder(order));
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]OrderDTO order)
        {
            orderService.updateOrder(order);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderService.deleteOrder(id);
        }
    }
}
