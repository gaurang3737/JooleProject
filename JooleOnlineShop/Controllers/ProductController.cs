using Joole.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product(int id)
        {
            Services service = new Services();
            int c = service.GetProductByID(id);
            ViewBag.count = c;
            return View();
        }
    }
}