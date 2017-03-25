using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Persets.Backend;
using System.Net.Http;

namespace Persets.Frontend.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            HttpController.Initialize();

            var response = HttpController.client.GetAsync("api/Category").Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");
            else
            {
                var repsonse = response.Content.ReadAsStringAsync();
                return View("Register");
            }
        }
    }
}