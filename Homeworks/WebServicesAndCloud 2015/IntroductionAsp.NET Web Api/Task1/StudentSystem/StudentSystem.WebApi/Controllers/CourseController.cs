namespace StudentSystem.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using Data;
    using Models;

    public class CoursesController : ApiController
    {
        private StudentsSystemData studentsData;

        public CoursesController()
        {
            this.studentsData = new StudentsSystemData();
        }

        public IHttpActionResult Get()
        {
            var courses = this.studentsData.Courses.All().ToList();
            return this.Ok<List<Course>>(courses);
        }

        public IHttpActionResult Get(string name)
        {
            var course = this.studentsData.Courses.SearchFor(co => co.Name.Contains(name)).FirstOrDefault();
            if (course != null)
            {
                return this.Ok(course);
            }

            return this.NotFound();
        }

        public IHttpActionResult Post(Course course)
        {
            this.studentsData.Courses.Add(course);
            this.studentsData.SaveChanges();

            //// warning Roslyn C# 6.0
            return this.Ok($"Successfull added course: {course.Name}");
        }
    }
}