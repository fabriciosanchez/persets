using Persets.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Persets.Frontend.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO Chamada para a api
            }

            return View(model);
        }

        public ActionResult LogIn ()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            HttpController.Initialize();

            var response = HttpController.client.PostAsJsonAsync("api/users", user).Result;
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