namespace StudentSystem.WebApi.Controllers
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    public class TestsController : ApiController
    {
        private StudentSystem.Data.StudentsSystemData studentDataManagement;

        public TestsController()
        {
            this.studentDataManagement = new Data.StudentsSystemData();
        }

        public IHttpActionResult Get()
        {
            var tests = this.studentDataManagement.Tests.All().Select(tst => new {
                CourseName = tst.Course.Name,
                StudentsCount = tst.Students.Count
            }).ToList();
            if (tests != null)
            {
                return this.Ok<ICollection>(tests);
            }

            return this.NotFound();
        }

        public IHttpActionResult Post(Test test)
        {
            this.studentDataManagement.Tests.Add(test);
            this.studentDataManagement.SaveChanges();

            return this.Ok("New Test added");
        }

    }
}