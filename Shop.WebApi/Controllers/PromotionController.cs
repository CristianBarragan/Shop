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
    public class PromotionController : Controller
    {
        private readonly IPromotionService promotionService;
        private readonly ILogger<PromotionController> logger;

        public PromotionController(IPromotionService promotionService, ILogger<PromotionController> logger)
        {
            this.promotionService = promotionService;
            this.logger = logger;
        }

        // GET: api/product
        [HttpGet]
        public JsonResult Get()
        {
            logger.LogWarning("Hi!");
            logger.LogInformation(";)");
            return Json(promotionService.getPromotions());
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(promotionService.getPromotion(id));
        }

        // POST api/product
        [HttpPost]
        public JsonResult Post([FromBody]PromotionDTO product)
        {
            return Json(promotionService.addPromotion(product));
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PromotionDTO product)
        {
            promotionService.updatePromotion(product);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            promotionService.deletePromotion(id);
        }
    }
}
