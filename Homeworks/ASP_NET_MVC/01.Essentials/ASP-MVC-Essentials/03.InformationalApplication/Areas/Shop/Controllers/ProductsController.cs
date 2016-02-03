using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationalApplication.Areas.Shop.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Shop/Products
        public ActionResult Index()
        {
            return View();
        }
    }
}