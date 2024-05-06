using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;

namespace TestFoodIt.Controllers
{
    public class ProductController : Controller
    {
        TasteContext context = new TasteContext();
       
        public ActionResult ProductList()
        {
            var value = context.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product p)
        {
            p.IsActive = true;
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductDelete(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public ActionResult ProductUpdate(int id)
        {
            List<SelectListItem> value2 = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.v = value2;
            var value = context.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ProductUpdate(Product p)
        {
            var value = context.Products.Find(p.ProductId);
            value.ProductName = p.ProductName;
            value.Description = p.Description;
            value.Price = p.Price;
            value.ImageUrl = p.ImageUrl;
            value.IsActive = true;
            value.CategoryId = p.CategoryId;
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}