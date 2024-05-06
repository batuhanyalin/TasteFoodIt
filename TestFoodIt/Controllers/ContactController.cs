using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Context;
using TestFoodIt.Entities;


namespace TestFoodIt.Controllers
{
    public class ContactController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ContactList()
        {
            var value = context.Contacts.OrderByDescending(x => x.SendDate).ToList();
            return View(value);
        }
        public ActionResult ContactDelete(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public ActionResult ContactUpdate(int id)
        {
            var value = context.Contacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ContactUpdate(Contact p)
        {
            var value = context.Contacts.Find(p.ContactId);
            value.Email = p.Email;
            value.Message = p.Message;
            value.NameSurname = p.NameSurname;
            value.Subject = p.Subject;
            value.IsRead = p.IsRead;
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
        public ActionResult ContactStatusUpdate(int id)
        {
            var value = context.Contacts.Find(id);

            if (value.IsRead != true)
            {
                value.IsRead = true;
            }
            else
            {
                value.IsRead = false;
            }
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}