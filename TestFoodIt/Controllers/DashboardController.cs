using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;

namespace TestFoodIt.Controllers
{
    public class DashboardController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Categories.Count();
            ViewBag.v2 = context.Products.Count();
            ViewBag.v3 = context.Chefs.Count();
            ViewBag.v4 = context.Reservations.Where(x=>x.ReservationStatus=="onaylandi").Count();
            ViewBag.v5 = context.Reservations.Where(x=>x.ReservationStatus=="bekliyor").Count();
            ViewBag.v6 = context.Reservations.Where(x=>x.ReservationStatus=="iptal").Count();
            
            return View();
        }
    }
}