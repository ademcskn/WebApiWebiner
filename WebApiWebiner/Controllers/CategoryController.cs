using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWebiner.Models.Dto;
using WebApiWebiner.Models.Orm;

namespace WebApiWebiner.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        //Metot Get ifadesi ile başladığı için HttpGet olarak işaretlemeye gerek yok.
        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> catList = db.Categories.Select(x => new CategoryModel()
            {
                KategoriAdi = x.CategoryName,
                Aciklamasi = x.Description
            }).ToList();
            return catList;
        }

        //Metodun isminin başında GET ifadesi olmazsa HttpGet olarak belirtmeliyiz. 
        [HttpGet]
        //Metodun alacağı id değerini "id" haricinde "categoryId" gibi değiştirirsek çalışmaz.
        public CategoryModel GetCategoryById(int id)
        {
            Categories cat = db.Categories.Find(id);
            CategoryModel catModel = new CategoryModel();
            catModel.KategoriAdi = cat.CategoryName;
            catModel.Aciklamasi = cat.Description;

            return catModel;
        }
    }
}