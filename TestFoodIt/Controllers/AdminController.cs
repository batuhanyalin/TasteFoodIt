using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;
using System.IO;

namespace TestFoodIt.Controllers
{
    public class AdminController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AdminList()
        {
            var value = context.Admins.ToList();
            return View(value);
        }
        public ActionResult AdminDelete(int id)
        {
            var value = context.Admins.Find(id);
            context.Admins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public ActionResult AdminCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCreate(Admin p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UserPhotoURL = "/Image/" + dosyaAdi + uzanti;
            }
            context.Admins.Add(p);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            var value = context.Admins.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdminUpdate(Admin p)
        {
            var value = context.Admins.Find(p.AdminId);
            if (p.UserPhotoURL!=null)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.UserPhotoURL = "/Image/" + dosyaAdi + uzanti;
                }
                value.Namesurname = p.Namesurname;
                value.Username = p.Username;
                value.Password = p.Password;
                value.UserPhotoURL = p.UserPhotoURL;
                context.SaveChanges();
                return RedirectToAction("AdminList");
            }
            return RedirectToAction("AdminList");
           
        }
    }
}