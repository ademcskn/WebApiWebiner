using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWebiner_2.Models.Dto;
using WebApiWebiner_2.Models.Orm;

namespace WebApiWebiner_2.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        public List<CategoryDto> GetAllCategories()
        {
            List<CategoryDto> catList = db.Categories.Select(x => new CategoryDto()
            {
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();

            return catList;
        }

        [HttpPost]
        public IHttpActionResult AddCategory(CategoryDto _model)
        {
            Categories cat = new Categories()
            {
                CategoryName = _model.Name,
                Description = _model.Description
            };

            db.Categories.Add(cat);
            db.SaveChanges();
            //return Ok();
            //return NotFound();
            return Json("success");
        }

    }
}