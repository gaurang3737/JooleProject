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
        //Get From Search
        [HttpGet]
        public ActionResult Product(string categoryId, string subcategoryId)
        {
            if (this.Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            int sub_id = Int32.Parse(subcategoryId);
            int cat_id = Int32.Parse(categoryId);
            List<tblProduct> prodlist = new List<tblProduct>();
            List<String> man_list = new List<string>();
            List<List<String>> props_value_list = new List<List<String>>();

            Services serv = new Services();
            ViewBag.cat_name = serv.GetCategoryName(cat_id);
            ViewBag.sub_cat_name = serv.GetSubCategoryName(sub_id);
            (prodlist, man_list, props_value_list) = serv.GetProductBySubCategoryID(sub_id);
            ViewBag.prod_data = prodlist;
            ViewBag.man_data = man_list;
            ViewBag.props_data = props_value_list;
            return View("Product");
        }

        //GET Product Details
        public ActionResult ProductList(int pid)
        {
            if (this.Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            Services service = new Services();
            List<List<List<string>>> productdetails = service.GetProductList(pid);
            ViewBag.Man = productdetails[0];
            ViewBag.IsType = productdetails[1];
            ViewBag.IsTechSpec = productdetails[2];
            return View("ProductList");
        }

        public ActionResult Logout()
        {
            //Clearing Sessions and Cookies
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        }
    }
}