using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Data.Models;
using Data.Repositories;

namespace TwitterSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IRepository<Tweet> tweetsRepo;
        private IRepository<Tag> tagsRepo;

        public AdminController()
        {
            var context = new Data.ApplicationDbContext();
            this.tweetsRepo = new EfGenericRepository<Tweet>(context);
            this.tagsRepo = new EfGenericRepository<Tag>(context);
        }

        // GET: Admin/Admin
        public ActionResult Index()
        {
            IList<Tweet> tweets = this.tweetsRepo.All().ToList();
            return View(tweets);
        }

        // POST Admin/Delete/{id}
        public ActionResult Delete(int id)
        {
            this.tweetsRepo.Delete(id);
            this.tweetsRepo.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}