using System.Web;
using System.Web.Mvc;
using TestFoodIt.Entities;

namespace TestFoodIt
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
