using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Context;
using TestFoodIt.Entities;

namespace TestFoodIt.Controllers
{
    public class CategoryController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
        public ActionResult CategoryProduct(int id)
        {
            var values = context.Products.Where(x => x.CategoryId == id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryCreate(Category p)
        {
            context.Categories.Add(p);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult CategoryDelete(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            var value = context.Categories.Find(p.CategoryId);
            value.CategoryName = p.CategoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}