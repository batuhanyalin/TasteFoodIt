using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;

namespace TestFoodIt.Controllers
{

    public class AdminLayoutController : Controller
    {

        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            ViewBag.userid = Session["ID"];
            ViewBag.namesurname = Session["Namesurname"];
            ViewBag.userphoto = Session["UserPhotoURL"];
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNotification()
        {
            var value = context.Notifications.OrderByDescending(x => x.Date).ToList();
            ViewBag.count = context.Notifications.Count(x => x.IsRead == false);
            return PartialView(value);
        }
        public PartialViewResult PartialMessage()
        {
            var value = context.Contacts.OrderByDescending(x => x.SendDate).ToList();
            ViewBag.count = context.Contacts.Count(x => x.IsRead == false);
            return PartialView(value);
        }
        public PartialViewResult PartialDashboardMessage()
        {
            var value = context.Contacts.OrderByDescending(x => x.SendDate).ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialDashboardReservation()
        {
            var value = context.Reservations.ToList();
            ViewBag.v1 = context.Reservations.Count();
            return PartialView(value);
        }
        public PartialViewResult PartialAreaChart()
        {
            return PartialView();
        }
    }
}