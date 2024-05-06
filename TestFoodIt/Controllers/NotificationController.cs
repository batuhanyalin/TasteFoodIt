using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;


namespace TestFoodIt.Controllers
{
    public class NotificationController : Controller
    {
        TasteContext contex = new TasteContext();
        public ActionResult NotificationList()
        {
            var value = contex.Notifications.OrderByDescending(x=>x.Date).ToList();
            return View(value);
        }

        public ActionResult NotificationDelete(int id)
        {
            var value = contex.Notifications.Find(id);
            contex.Notifications.Remove(value);
            contex.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult NotificationCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotificationCreate(Notification p)
        {
            p.Date = DateTime.Now;
            p.IsRead = false;
            contex.Notifications.Add(p);
            contex.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult NotificationUpdate(int id)
        {
            var value = contex.Notifications.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult NotificationUpdate(Notification p)
        {
            var value = contex.Notifications.Find(p.NotificationId);
            value.Description = p.Description;
            value.Icon = p.Icon;
            value.IsRead = p.IsRead;
            value.IconColor = p.IconColor;
            contex.SaveChanges();
            return RedirectToAction("NotificationList");
        }

        public ActionResult ChangeNotificationStatus(int id)
        {
            var value = contex.Notifications.Find(id);
            if (value.IsRead==true)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            contex.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}