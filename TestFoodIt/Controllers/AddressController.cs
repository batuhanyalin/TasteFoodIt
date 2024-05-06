using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;

namespace TestFoodIt.Controllers
{
    public class AddressController : Controller
    {
        TasteContext contex = new TasteContext();
        public ActionResult AddressList()
        {
            var value = contex.Addresses.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddressCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddressCreate(Address p)
        {
            contex.Addresses.Add(p);
            contex.SaveChanges();
            return RedirectToAction("AddressList");
        }
        public ActionResult AddressDelete(int id)
        {
            var value = contex.Addresses.Find(id);
            contex.Addresses.Remove(value);
            contex.SaveChanges();
            return RedirectToAction("AddressList");
        }
        [HttpGet]
        public ActionResult AddressUpdate(int id)
        {
            var value = contex.Addresses.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AddressUpdate(Address p)
        {
            var value = contex.Addresses.Find(p.AddressId);
            value.FullAddress = p.FullAddress;
            value.Description = p.Description;
            value.Phone = p.Phone;
            value.Email = p.Email;
            value.Website = p.Website;
            contex.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}