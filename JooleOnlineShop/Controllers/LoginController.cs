using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.Service;
using Joole.Service.Models;
using JooleOnlineShop.Models;
using System.IO;

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
        public ActionResult Login_Verify(string username, string password)
        {
            Services service = new Services();
            bool isLogin = service.Login(username, password);
            ViewBag.Title = "Server Login";

            if (isLogin)
            {
                HttpContext.Session.Add("username", username);
                return RedirectToAction("Search", "Search");
            }
            else
            {
                ViewBag.message = "Invalid Credentials! Please try again!";
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult Submit(string username1,string emailid,string password1, HttpPostedFileBase image1)
        {
            Services service = new Services();
           
            if(image1 != null){
                byte[] b = new byte[image1.ContentLength];
                image1.InputStream.Read(b, 0, image1.ContentLength);
                service.Submit_User(username1, emailid, password1, b);
            }
            else {
                service.Submit_User(username1, emailid, password1, null);
            }
            ViewBag.message = "User Successfully Added!";
            return View("Login");
        }

        public ActionResult UserList() {
            Services service = new Services();
            List<User> users = service.GetUserList();
            return View("UserList", users);
        }
    }
}