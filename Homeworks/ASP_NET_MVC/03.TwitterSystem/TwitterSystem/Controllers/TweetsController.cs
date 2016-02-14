namespace TwitterSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Data.Repositories;
    using Microsoft.AspNet.Identity;
    using TwitterSystem.Models;

    public class TweetsController : Controller
    {
        private IRepository<Tweet> tweetsRepo;
        private IRepository<Tag> tagsRepo;

        public TweetsController()
        {
            var context = new Data.ApplicationDbContext();
            this.tweetsRepo = new EfGenericRepository<Tweet>(context);
            this.tagsRepo = new EfGenericRepository<Tag>(context);
        }

        // GET: Tweets
        public ActionResult Index()
        {
            IList<Tweet> tweets = this.tweetsRepo.All().ToList();
            return View(tweets);
        }

        // GET: Tweets/Details/5
        public ActionResult Details(int id)
        {
            Tweet tweet = this.tweetsRepo.GetById(id);

            return View(tweet);
        }

        [Authorize]
        // GET: Tweets/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Tweets/MyTweets
        [Authorize]
        public ActionResult MyTweets()
        {
            string userId = User.Identity.GetUserId();
            IList<Tweet> tweets = this.tweetsRepo.All().Where(t => t.UserId == userId).ToList();
            return View(tweets);
        }

        // POST: Tweets/Create
        [ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost]
        public ActionResult Create(InputTweetModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            Tweet tweet = new Tweet()
            {
                Content = inputModel.Content,
                DatePosted = DateTime.Now,
                UserId = this.User.Identity.GetUserId(),
                Tags = new HashSet<Tag>()
            };

            IList<Tag> dbTags = this.tagsRepo.All().ToList();
            IList<string> tags = inputModel.Tags.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var item in tags)
            {
                // Constants are some object class from ASP .NET 
                if (!Regex.IsMatch(item, Common.Constants.Pattern, RegexOptions.IgnoreCase))
                {
                    continue;
                }

                string hastag = item.Substring(1);
                // This does not makes query to database because I called .ToList() above ↑.
                // If you want turn on a SQL Profiler. 
                Tag tag = dbTags.FirstOrDefault(t => t.Name == hastag);
                if (tag == null)
                {
                    tag = new Tag { Name = hastag };
                    this.tagsRepo.Add(tag);
                    this.tagsRepo.SaveChanges();
                }

                tweet.Tags.Add(tag);
            }

            this.tweetsRepo.Add(tweet);
            this.tweetsRepo.SaveChanges();
            return this.RedirectToAction("Details", new { id = tweet.Id });
        }

        // GET: Tweets/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Tweet tweet = this.tweetsRepo.GetById(id);
            InputTweetModel editModel = new InputTweetModel()
            {
                Content = tweet.Content,
                Tags = "#" + string.Join(" #", tweet.Tags.Select(t => t.Name))
            };

            return View(editModel);
        }

        // POST: Tweets/Edit/5
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, InputTweetModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            Tweet dbTweet = this.tweetsRepo.GetById(id);
            if (dbTweet == null)
            {
                return this.RedirectToAction("Index");
            }

            dbTweet.Content = inputModel.Content;

            this.tweetsRepo.Update(dbTweet);
            this.tweetsRepo.SaveChanges();

            return this.RedirectToAction("Details", new { id = dbTweet.Id });
        }

        //// POST: Tweets/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    this.tweetsRepo.Delete(id);
        //    return this.RedirectToAction("Index");
        //}
    }
}
