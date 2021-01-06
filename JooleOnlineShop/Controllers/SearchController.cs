using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.Service;
using Joole.Service.Models;

namespace JooleOnlineShop.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Search()
        {
            Services service = new Services();
            List<Category> categories = service.GetCategoryList();
            return View("Search", categories);
        }

        //public ActionResult Search_Submmit() {
        //    return View();
        //}

        public ActionResult GetSubCateListByCatID(int categoryId)
        {
            Services serivce = new Services();
            List<SubCategory> subCategories = serivce.GetSubCatByCatID(categoryId);
            return Json(subCategories, JsonRequestBehavior.AllowGet);
        }
    }
}