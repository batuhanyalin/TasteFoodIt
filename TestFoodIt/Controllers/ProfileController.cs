using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;
using TestFoodIt.Context;

namespace TestFoodIt.Controllers
{
    public class ProfileController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult ProfileSettings()
        {
            ViewBag.username = Session["Username"];
            ViewBag.password = Session["Password"];
            ViewBag.id = Session["ID"];
            return View();
        }

        [HttpPost]
        public ActionResult ProfileSettings(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                if (model.NewPassword==model.ConfirmPassword)
                {
                    var user = context.Admins.FirstOrDefault(x => x.Username == User.Identity.Name);
                    if (user!=null)
                    {
                        user.Password = model.NewPassword;
                        context.SaveChanges();
                    }
                    return RedirectToAction("ProfileSettings");
                }
                else
                {
                    ModelState.AddModelError("", "Girilen şifreler birbirleriyle uyumsuz. Şifre değiştirilemedi.");
                    return View(model);
                }
            }
            return View(model);
            //string password1 = "";
            //string password2 = "";
            //password1 = Request.Form["Password1"];
            //password2 = Request.Form["Password2"];
            //if (password1 == password2&& password1!=null&&password2!=null)
            //{
            //    var value = context.Admins.Find(p.AdminId);
            //    value.Password = p.Password;
            //    context.SaveChanges();
            //    ModelState.AddModelError("", "Şifre başarıyla güncellendi.");
            //    return RedirectToAction("ProfileSettings");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Girilen şifreler birbirleriyle uyumsuz. Şifre değiştirilemedi.");
            //    return RedirectToAction("ProfileSettings", "Profile");
            //}
        }
    }
}