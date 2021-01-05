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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList()
        {
            Services service = new Services();
            List<List<List<string>>> productdetails = service.GetProductList();
            ViewBag.Man = productdetails[0];
            ViewBag.IsType = productdetails[1];
            ViewBag.IsTechSpec = productdetails[2];
            return View("ProductList");
        }
    }
}