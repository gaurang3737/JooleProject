using Joole.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.DAL;

namespace JooleOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product(int id = 1)
        {
            Services serv = new Services();
            List<tblProduct> prodlist = new List<tblProduct>();
            List<String> man_list = new List<string>();
            (prodlist, man_list) = serv.GetProductBySubCategoryID(id);
            ViewBag.prod_data = prodlist;
            ViewBag.man_data = man_list;
            return View("Product");
        }
    }
}