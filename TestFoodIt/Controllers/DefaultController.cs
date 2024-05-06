using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;


namespace TestFoodIt.Controllers
{
    public class DefaultController : Controller
    {
        TasteContext context = new TasteContext();

        //Layout Page
        public ActionResult DefaultL()
        {

            return View();
        }
        //Main Page
        public ActionResult Index()
        {
            return View();
        }
        //Menu Page
        public ActionResult Menu()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        //Chefs Page
        public ActionResult Chef()
        {
            var value = context.Chefs.ToList();
            return View(value);
        }
        //Reservation Page
        [HttpGet]
        public ActionResult Reservation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reservation(Reservation p)
        {
            return RedirectToAction("Index");
        }
        //About Page
        public ActionResult About()
        {
            return View();
        }
        //Contact Page
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact p)
        {
            p.SendDate = DateTime.Now;
            context.Contacts.Add(p);
            context.SaveChanges();
            return RedirectToAction("Contact");
        }
        //Partial Pages -----------------------------------------------------------------------
        public PartialViewResult PartialAddress()
        {
            ViewBag.address = context.Addresses.Select(x => x.FullAddress).FirstOrDefault();
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.website = context.Addresses.Select(x => x.Website).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialIstatistic()
        {
            return PartialView();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialWrap()
        {
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.description = context.Addresses.Select(x => x.Description).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        //Navbardaki sağ üstte yer alan sosyal medya ikonları
        public PartialViewResult PartialNavbarSocialMedia()
        {
            var value = context.SocialMedias.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialLoader()
        {
            return PartialView();
        }
        public PartialViewResult PartialSlider()
        {
            var value = context.Sliders.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            var value = context.Abouts.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialMiddleBanner()
        {
            return PartialView();
        }
        public PartialViewResult PartialProduct()
        {
            return PartialView();
        }
        public PartialViewResult PartialTestimonial()
        {
            var value = context.Testimonials.ToList();
            return PartialView(value);
        }
        //-----------Footer Bölümü
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        //PartialFooter içindeki sosyal medya butonları
        public PartialViewResult PartialFooterSocialMedia()
        {
            var value = context.SocialMedias.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialFooterOpenDayHour()
        {
            var value = context.OpenDayHours.ToList();
            return PartialView(value);
        }
        //----------
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialChef()
        {
            var value = context.Chefs.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialBottomBanner()
        {
            return PartialView();
        }
        public PartialViewResult PartialBookingBanner()
        {
            return PartialView();
        }
        public PartialViewResult PartialMenu()
        {
            var value = context.Products.ToList();
            return PartialView(value);
        }
        public ActionResult ReservationAppointment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReservationAppointment(Reservation p)
        {
            if (ModelState.IsValid)
            {
                int reservationCount = context.Reservations.Count(x => x.ReservationDate == p.ReservationDate);

                if (reservationCount >= 4)
                {
                    ModelState.AddModelError("", "Bu tarih için maksimum sayıda rezervasyon alındı. Lütfen başka bir tarih seçin.");
                    return View(p);
                }

                p.ReservationStatus = "bekliyor"; 
                context.Reservations.Add(p);
                context.SaveChanges();

                return RedirectToAction("Index", "Default"); 
            }
            return View(p);
        }
    }
}
    
