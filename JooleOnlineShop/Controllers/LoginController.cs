using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.Service;
using Joole.Service.Models;
using JooleOnlineShop.Models;


namespace JooleOnlineShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_Submmt(UserVM user) {
            Services service = new Services();
            Boolean isLogin = service.Login(user.Email, user.Password);
            if (isLogin) {
                return View("Login");
            }
            return View("Login");
        }

        public ActionResult UserList() {
            Services service = new Services();
            List<User> users = service.GetUserList();
            return View("UserList", users);
        }
    }
}