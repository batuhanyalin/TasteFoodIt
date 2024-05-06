using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFoodIt.Context;

namespace TestFoodIt.Controllers
{
    public class MenuController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult MenuList()
        {
            var values = context.Products.ToList();
            return View(values);
        }
    }
}
