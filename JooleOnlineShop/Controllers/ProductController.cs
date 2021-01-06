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
            List<List<List<string>>> productdetails = service.GetProductList(1);
            ViewBag.Man = productdetails[0];
            ViewBag.IsType = productdetails[1];
            ViewBag.IsTechSpec = productdetails[2];
            return View("ProductList");
        }

        public ActionResult CompareProducts()
        {
            Services service = new Services();
            int c = 0;
            if (c == -1)
            {
                List<List<List<string>>> product1details = service.GetCompareProducts(1);
                List<List<List<string>>> product2details = service.GetCompareProducts(2);
                product1details[0].AddRange(product2details[0]);
                product1details[1].AddRange(product2details[1]);
                product1details[2].AddRange(product2details[2]);

                ViewBag.CompareMan = product1details[0];
                ViewBag.CompareIsType = product1details[1];
                ViewBag.CompareIsTechSpec = product1details[2];
                ViewBag.Compare2 = 1;
            }
            else
            {
                List<List<List<string>>> product1details = service.GetCompareProducts(1);
                List<List<List<string>>> product2details = service.GetCompareProducts(2);
                List<List<List<string>>> product3details = service.GetCompareProducts(3);
                product1details[0].AddRange(product2details[0]);
                product1details[0].AddRange(product3details[0]);

                product1details[1].AddRange(product2details[1]);
                product1details[1].AddRange(product3details[1]);

                product1details[2].AddRange(product2details[2]);
                product1details[2].AddRange(product3details[2]);

                ViewBag.CompareMan = product1details[0];
                ViewBag.CompareIsType = product1details[1];
                ViewBag.CompareIsTechSpec = product1details[2];
                ViewBag.Compare2 = 0;
            }
            
            return View("CompareProducts");
        }
    }
}