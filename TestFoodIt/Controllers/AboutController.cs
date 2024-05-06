using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Context;
using TestFoodIt.Entities;

namespace TestFoodIt.Controllers
{
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AboutList()
        {
            var value = context.Abouts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AboutCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutCreate(About p)
        {
            context.Abouts.Add(p);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult AboutDelete(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult AboutUpdate(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult AboutUpdate(About p)
        {
            var value = context.Abouts.Find(p.AboutId);
            value.Description = p.Description;
            value.Title = p.Title;
            value.ImageURL = p.ImageURL;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}