using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Context;
using TestFoodIt.Entities;

namespace TestFoodIt.Controllers
{
    public class ChefsController : Controller
    {
        TasteContext context = new TasteContext();

        //Admin Panel--
        public ActionResult ChefList()
        {
            var value = context.Chefs.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult ChefCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChefCreate(Chef p)
        {
            var value = context.Chefs.Add(p);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }

        public ActionResult ChefDelete(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }

        [HttpGet]
        public ActionResult ChefUpdate(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult ChefUpdate(Chef p)
        {
            var value = context.Chefs.Find(p.ChefId);
            value.NameSurname = p.NameSurname;
            value.Title = p.Title;
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
    }
}
