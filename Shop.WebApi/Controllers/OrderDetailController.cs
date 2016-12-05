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
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService orderDetailService;
        private readonly ILogger<OrderDetailController> logger;

        public OrderDetailController(IOrderDetailService orderDetailService, ILogger<OrderDetailController> logger)
        {
            this.orderDetailService = orderDetailService;
            this.logger = logger;
        }

        // GET: api/product
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    return Json(orderDetailService.getOrderDetails());
        //}

        // GET api/product/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(orderDetailService.getOrderDetail(id));
        }

        // POST api/product
        [HttpPost]
        public JsonResult Post([FromBody]OrderDetailDTO order)
        {
            return Json(orderDetailService.addOrderDetail(order));
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]OrderDetailDTO order)
        {
            orderDetailService.updateOrderDetail(order);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderDetailService.deleteOrderDetail(id);
        }
    }
}
