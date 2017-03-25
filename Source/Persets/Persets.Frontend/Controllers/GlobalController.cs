using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

// FONTE: http://www.dotnettricks.com/learn/mvc/understanding-internationalization-in-aspnet-mvc

namespace Persets.Frontend.Controllers
{
    public class GlobalController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Session[Constants.CurrentCulture] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(CurrentCulture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(CurrentCulture);
            }
        }

        public ActionResult ChangeLanguage(string language, string currentUrl)
        {
            CurrentCulture = language;
            return Redirect(currentUrl);
        }

        protected string CurrentCulture
        {
            get
            {
                var currentLanguage = Session[Constants.CurrentCulture];

                if (currentLanguage != null)
                    return currentLanguage.ToString();

                return Constants.DefaultLanguage;
            }
            set
            {
                Session[Constants.CurrentCulture] = value;
            }
        }
    }


}