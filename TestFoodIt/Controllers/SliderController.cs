using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Context;
using TestFoodIt.Entities;

namespace TestFoodIt.Controllers
{
    public class SliderController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult SliderList()
        {
            var value = context.Sliders.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SliderCreate(Slider p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.SliderUrl = "/Image/" + dosyaAdi + uzanti;
            }
            context.Sliders.Add(p);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
        public ActionResult SliderDelete(int id)
        {
            var value = context.Sliders.Find(id);
            context.Sliders.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
        [HttpGet]
        public ActionResult SliderUpdate(int id)
        {
            var value = context.Sliders.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult SliderUpdate(Slider p)
        {
            if (Request.Files.Count>0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.SliderUrl = "/Image/" + dosyaAdi + uzanti;
            }
            var value = context.Sliders.Find(p.SliderId);
            value.SliderHeading = p.SliderHeading;
            value.SliderDescription = p.SliderDescription;
            value.SliderTitle = p.SliderTitle;
            value.SliderUrl = p.SliderUrl;
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
    }
}