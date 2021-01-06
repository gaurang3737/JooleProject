using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost]
        public ActionResult Product()
        {
            ViewBag.categoryId = Request.Form["categoryId"];
            ViewBag.subcategoryId = Request.Form["subcategoryId"];
            return View("Product");
        }
    }
}