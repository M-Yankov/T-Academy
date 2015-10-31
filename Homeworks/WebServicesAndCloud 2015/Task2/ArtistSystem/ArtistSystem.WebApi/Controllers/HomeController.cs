
namespace ArtistSystem.WebApi.Controllers
{
    using System.Web.Http;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "HomePage";

            return View();
        }

        public ActionResult Content()
        {
            ViewBag.Title = "All content";

            return View();
        }
    }
}