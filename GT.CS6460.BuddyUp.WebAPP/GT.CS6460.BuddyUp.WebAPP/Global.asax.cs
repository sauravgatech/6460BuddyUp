using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GT.CS6460.BuddyUp.WebAPP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static bool IsAuthenticated = false;
        public static string userEmail;
        public static string userName;
        public static string currentGroupCode;
        public static string currentCourseCode;
        public static Dictionary<string, string> courses = new Dictionary<string,string>();
        public static Dictionary<string, string> courseDescription = new Dictionary<string, string>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
