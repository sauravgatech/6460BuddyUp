using System.Web;
using System.Web.Mvc;

namespace GT.CS6460.BuddyUp.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
