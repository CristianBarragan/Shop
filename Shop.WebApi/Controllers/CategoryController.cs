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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            this.categoryService = categoryService;
            this.logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(categoryService.getCategories());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(categoryService.getCategory(id));
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]CategoryDTO category)
        {
            return Json(categoryService.addCategory(category));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CategoryDTO category)
        {
            categoryService.updateCategory(category);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryService.deleteCategory(id);
        }
    }
}
