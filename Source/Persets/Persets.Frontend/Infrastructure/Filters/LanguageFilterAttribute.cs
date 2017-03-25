using Persets.Frontend.ViewResources.Profile;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Persets.Frontend.Infrastructure.Filters
{
    public class LanguageFilterAttribute : ActionFilterAttribute
    {
        private static List<SelectListItem> _avaliableLanguages = new List<SelectListItem>();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var currentSession = filterContext.HttpContext.Session[Constants.CurrentCulture];
            string currentLanguage = currentSession != null ? currentSession.ToString() : Constants.DefaultLanguage;

            List<SelectListItem> avaliableLanguages = new List<SelectListItem>();
            avaliableLanguages.Add(new SelectListItem() { Text = Resource.EnglishLanguageName, Value = "en", Selected = (currentLanguage == "en") });
            avaliableLanguages.Add(new SelectListItem() { Text = Resource.PortugueseLanguageName, Value = "pt", Selected = (currentLanguage == "pt") });
            filterContext.Controller.ViewBag.AvaliableLanguages = avaliableLanguages;
        }
    }
}