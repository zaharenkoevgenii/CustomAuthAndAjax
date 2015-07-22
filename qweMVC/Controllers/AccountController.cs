using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using qweMVC.Models;

namespace qweMVC.Controllers
{
    public class AccountController : Controller
    {
        readonly DataContext _context = new DataContext();

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("PartialContacts", "Home");
            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user != null)
            {
                var roles = user.Roles.Select(m => m.RoleName).ToArray();

                var serializeModel = new CustomPrincipalSerializeModel {UserId = user.UserId, Roles = roles};
                var userData = JsonConvert.SerializeObject(serializeModel);
                var authTicket = new FormsAuthenticationTicket(
                    1,
                    user.Email,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    false,
                    userData);

                var encTicket = FormsAuthentication.Encrypt(authTicket);
                var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);
                return RedirectToAction("PartialContacts", "Home");
            }
            ModelState.AddModelError("", "Incorrect username and/or password");
            return RedirectToAction("PartialContacts", "Home");
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("PartialContacts", "Home");
        }

        [HttpPost]
        public void JsRegister()
        {
            var a = Request.Form["data"].Split(',');
            var model = new RegisterViewModel
            {
                Email = a[1],
                Password = a[2],
                Username = a[0]
            };
            Register(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var user1 = new User { Username = model.Username, Email = model.Email, Password = model.Password, Roles = new List<Role>() };
            user1.Roles.Add(_context.Roles.First(r => r.RoleName == "User"));
            _context.Users.Add(user1);
            _context.SaveChanges();
            return RedirectToAction("PartialContacts", "Home");
        }
    }
}
