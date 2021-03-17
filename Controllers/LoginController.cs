using DB_ex1.Models;
using DB_Models;
using DB_ex1.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ex1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ResetPassword() 
        {
            return View();

        }
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {

            }


            var result = new AccountModel().Login(model.Username, model.Password);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { Username = model.Username });
                return RedirectToAction("Index", "Home");
            }
            else ModelState.AddModelError("", "Username or password is incorrect.");

            return View(model);
        }
    }
}