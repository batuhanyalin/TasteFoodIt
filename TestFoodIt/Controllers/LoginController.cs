using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestFoodIt.Context;
using TestFoodIt.Entities;

namespace TestFoodIt.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {     
            var value = context.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (value!=null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, true);
                Session["Username"] = value.Username;
                Session["ID"] = value.AdminId;
                Session["Namesurname"] = value.Namesurname;
                Session["UserPhotoURL"] = value.UserPhotoURL;
                Session["Password"] = value.Password;
                return RedirectToAction("Index", "Dashboard",p.AdminId);             
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); 
            return RedirectToAction("Index", "Login");
        }
    }
}