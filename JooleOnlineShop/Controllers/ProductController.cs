﻿using Joole.Service;
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
        //Get From Search
        [HttpGet]
        public ActionResult Product(string categoryId, string subcategoryId)
        {
            if (HttpContext.Session["username"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            TempData["img"] = HttpContext.Session["user_img"];

            int sub_id = Int32.Parse(subcategoryId);
            int cat_id = Int32.Parse(categoryId);
            List<tblProduct> prodlist = new List<tblProduct>();
            List<String> man_list = new List<string>();
            List<List<String>> props_value_list = new List<List<String>>();
            Services serv = new Services();
            List<Category> categories = serv.GetCategoryList();//for top-search bar
            ViewBag.cat_name = serv.GetCategoryName(cat_id);
            ViewBag.sub_cat_name = serv.GetSubCategoryName(sub_id);
            (prodlist, man_list, props_value_list) = serv.GetProductBySubCategoryID(sub_id);
            ViewBag.prod_data = prodlist;
            ViewBag.man_data = man_list;
            ViewBag.props_data = props_value_list;
            return View("Product", categories);
        }

        //GET Product Details
        [HttpGet]
        public ActionResult ProductList(int pid)
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