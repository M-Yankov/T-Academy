using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationalApplication.Areas.Shop.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Shop/Categories
        public ActionResult Index()
        {
            return View();
        }

        // GET: Shop/Search
        public ActionResult Search()
        {
            return View();
        }
    }
}