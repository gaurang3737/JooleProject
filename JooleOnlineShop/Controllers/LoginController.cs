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
            Boolean isLogin = service.Login(username, password);
            if (isLogin)
            {
                List<User> users = service.GetUserList();
                return View("UserList", users);
            }
            return View("Login");

        }

        [HttpPost]
        public ActionResult Submit(string username1,string emailid,string password1, HttpPostedFileBase image1)
        {
            Services service = new Services();
           
            if(image1 != null){
                byte[] b = new byte[image1.ContentLength];
                //ViewBag.data = b;
                image1.InputStream.Read(b, 0, image1.ContentLength);
                service.Submit_User(username1, emailid, password1, b);
            }
            else {
                //ViewBag.data = "wkgebwkg";
                service.Submit_User(username1, emailid, password1, null);
            }



            /*int c = users.Count + 1;
            User user = new User
            {
                Id = c,
                Name = username1,
                Email = emailid,
                Password = password1
            };
            
            users.Add(user);*/
            List<User> users = service.GetUserList();
            return View("UserList", users);
            //return View("Login");
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