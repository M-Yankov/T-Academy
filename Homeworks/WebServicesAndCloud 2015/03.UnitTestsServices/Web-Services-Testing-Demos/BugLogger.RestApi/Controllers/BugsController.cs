namespace BugLogger.RestApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using BugLogger.RestApi.Models;

    public class BugsController : ApiController
    {
        private IRepository<Bug> repo;

        public BugsController()
            : this(new DbBugsRepository(new BugLoggerDbContext()))
        {
        }

        public BugsController(IRepository<Bug> repository)
        {
            this.repo = repository;
        }

        [EnableCors("*", "*", "*")]
        public IQueryable<ResponseBugModel> GetAll()
        {
            var bugs = this.repo.All().ProjectTo<ResponseBugModel>();
            return bugs;
        }

        public IQueryable<ResponseBugModel> GetCount(int count)
        {
            return this.GetAll()
                    .Take(count);
        }

        public IHttpActionResult GetBugsByStartDate(DateTime date)
        {
            return this.GetBugsInRange(date, DateTime.MaxValue);
        }

        public IHttpActionResult GetBugsInRange(DateTime start, DateTime end)
        {
            var bugs = this.GetAll();
            var result = new List<ResponseBugModel>();
            foreach (var bug in bugs)
            {
                if (!string.IsNullOrEmpty(bug.LogDate))
                {
                    DateTime objDate = DateTime.Parse(bug.LogDate);
                    if (objDate >= start && objDate <= end)
                    {
                        result.Add(bug);
                    }
                }
            }

            return this.Ok(result);
        }

        public IQueryable<ResponseBugModel> GetByStatusType(string type)
        {
            return this.GetAll().Where(x => x.Status == type);
        }

        [HttpPut]
        public IHttpActionResult PutBug(int id, [FromBody]SaveBugModel updatedBug)
        {
            Bug bug = this.repo.Find(id);
            if (bug == null)
            {
                return this.BadRequest("Id not found");
            }

            Mapper.DynamicMap(updatedBug, bug);
            this.repo.Update(bug);
            this.repo.Save();

            return this.Ok("Changes Saved!");
        }

        [HttpPost]
        public IHttpActionResult PostBug(SaveBugModel bug)
        {
            if (bug == null)
            {
                var ex = new ArgumentException("No data sent!");
                return this.BadRequest(ex.Message);
            }

            if (string.IsNullOrEmpty(bug.Text))
            {
                var ex = new ArgumentException("Text of the bug cannot be null or empty.");
                return this.BadRequest(ex.Message);
            }

            Bug model = Mapper.Map(bug, new Bug());

            this.repo.Add(model);
            this.repo.Save();

            var returnModel = Mapper.Map(model, new ResponseBugModel());

            return this.Created(new Uri("http://localhost:11350/api/bugs"), returnModel);
        }
    }
}
