using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Persets.Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterFilters(GlobalFilters.Filters);
        }

        public void Session_Start(object sender, EventArgs e)
        {
            //if (Request.QueryString["lang"] != null)
            //{
            //    Session["CurrentCulture"] = Request.QueryString["lang"];
            //}
        }
    }
}
