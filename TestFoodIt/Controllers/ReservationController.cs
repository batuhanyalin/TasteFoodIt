using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Context;
using TestFoodIt.Entities;

namespace TestFoodIt.Controllers
{
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult ReservationList()
        {
            var value = context.Reservations.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ReservationCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReservationCreate(Reservation p)
        {
            p.ReservationStatus = "bekliyor";
            context.Reservations.Add(p);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ReservationDelete(int id)
        {
            var value = context.Reservations.Find(id);
            context.Reservations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult ReservationUpdate(int id)
        {
            var value = context.Reservations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ReservationUpdate(Reservation p)
        {
            var value = context.Reservations.Find(p.ReservationId);
            value.Name = p.Name;
            value.Phone = p.Phone;
            value.GuestCount = p.GuestCount;
            value.ReservationStatus = p.ReservationStatus;
            value.ReservationDate = p.ReservationDate;
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}