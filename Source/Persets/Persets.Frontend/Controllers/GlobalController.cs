using System.Globalization;
using System.Threading;
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

            string languageRoute = requestContext.RouteData.Values["lang"] != null ? requestContext.RouteData.Values["lang"].ToString() : string.Empty;

            if (CurrentCulture != languageRoute)
            {
                CurrentCulture = languageRoute;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(GetCurrentCulture(CurrentCulture));
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(GetCurrentCulture(CurrentCulture));
            }
        }

        public ActionResult ChangeLanguage(string language, string currentUrl)
        {
            CurrentCulture = language;

            if (!string.IsNullOrEmpty(currentUrl))
            {
                string[] paths = currentUrl.Split('/');
                currentUrl = string.Empty;

                for (int i = 0; i < paths.Length; i++)
                    if (i != 1 && !currentUrl.EndsWith("/")) currentUrl += "/" + paths[i];
            }

            return Redirect("/" + language + currentUrl);
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

        private string GetCurrentCulture(string language)
        {
            switch (language)
            {
                case "en":
                    return "en-US";
                case "pt":
                    return "pt-BR";
                default:
                    return "en-US";
            }
        }
    }


}