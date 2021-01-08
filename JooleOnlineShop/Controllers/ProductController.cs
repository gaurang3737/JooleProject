using Joole.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.DAL;
using Joole.Service.Models;

namespace JooleOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        //Get for Product
        [HttpGet]
        public ActionResult Product(string categoryId = "null", string subcategoryId = "null", string f = "1,0,1")
        {
            if (HttpContext.Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //Set Category and SubCategory ids as sessions
            if(categoryId != "null")
            {
                HttpContext.Session["cat_id"] = categoryId;
                HttpContext.Session["sub_cat_id"] = subcategoryId;
            }
            else
            {
                categoryId = (string)HttpContext.Session["cat_id"];
                subcategoryId = (string)HttpContext.Session["sub_cat_id"];
            }

            Services serv = new Services();
            List<Category> categories = serv.GetCategoryList();//for top-search bar
            TempData["img"] = HttpContext.Session["user_img"];

            if (categoryId != null && subcategoryId != null)
            {
                int sub_id = Int32.Parse(subcategoryId);
                int cat_id = Int32.Parse(categoryId);

                if(cat_id > 1 || sub_id > 2)
                {
                    ViewBag.message = "No Data found!";
                }

                List<tblProduct> prodlist = new List<tblProduct>();
                List<string> man_list = new List<string>();
                List<List<string>> props_value_list = new List<List<string>>();

                ViewBag.cat_name = serv.GetCategoryName(cat_id);
                ViewBag.sub_cat_name = serv.GetSubCategoryName(sub_id);
                (prodlist, man_list, props_value_list) = serv.GetProductBySubCategoryID(sub_id);
                ViewBag.prod_data = prodlist;
                ViewBag.man_data = man_list;
                ViewBag.props_data = props_value_list;

                ViewBag.tech_spec_filter_data = serv.GetTechSpecFilter(sub_id); //Getting Filter Data
                ViewBag.fstring = f;
                //Setting session for compare page 
                HttpContext.Session["cat_name"] = ViewBag.cat_name;
                HttpContext.Session["sub_cat_name"] = ViewBag.sub_cat_name;
            }
            else
            {
                ViewBag.message = "No Data found!";
            }
            return View("Product", categories);
        }

        //GET Product Details
        [HttpGet]
        public ActionResult ProductList(int pid = 1)
        {
            if (HttpContext.Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            TempData["img"] = HttpContext.Session["user_img"];
            Services service = new Services();
            List<List<List<string>>> productdetails = service.GetProductList(pid);
            ViewBag.Man = productdetails[0];
            ViewBag.IsType = productdetails[1];
            ViewBag.IsTechSpec = productdetails[2];
            List<Category> categories = service.GetCategoryList();//for top-search bar
            return View("ProductList", categories);
        }

        [HttpGet]
        public ActionResult CompareProducts(int a, int b, int c = -1)
        {
            if (HttpContext.Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            TempData["img"] = HttpContext.Session["user_img"];
            Services service = new Services();
            if (c == -1)
            {
                List<List<List<string>>> product1details = service.GetCompareProducts(a);
                List<List<List<string>>> product2details = service.GetCompareProducts(b);
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
                List<List<List<string>>> product1details = service.GetCompareProducts(a);
                List<List<List<string>>> product2details = service.GetCompareProducts(b);
                List<List<List<string>>> product3details = service.GetCompareProducts(c);
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
            List<Category> categories = service.GetCategoryList();//for top-search bar

            ViewBag.cat_name = HttpContext.Session["cat_name"];
            ViewBag.sub_cat_name = HttpContext.Session["sub_cat_name"];
            return View("CompareProducts", categories);
        }
        
        public ActionResult Logout()
        {
            //Clearing Sessions
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        }
    }
}