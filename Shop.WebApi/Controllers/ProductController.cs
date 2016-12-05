using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Microsoft.Extensions.Logging;
using DtoEntities;
using System.Net.Http;
using System.Net;
using System.Text;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        // GET: api/product
        [HttpGet]
        public JsonResult Get()
        {
            logger.LogWarning("Hi!");
            logger.LogInformation(";)");
            return Json(productService.getProducts());
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(productService.getProduct(id));
        }

        // POST api/product
        [HttpPost]
        public JsonResult Post([FromBody]ProductDTO product)
        {
            return Json(productService.addProduct(product));
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProductDTO product)
        {
            productService.updateProduct(product);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.deleteProduct(id);
        }
    }
}
