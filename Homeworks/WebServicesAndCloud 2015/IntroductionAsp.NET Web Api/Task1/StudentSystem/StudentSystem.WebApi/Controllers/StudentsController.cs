namespace StudentSystem.WebApi.Controllers
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    public class StudentsController : ApiController
    {
        private StudentsSystemData data;

        public StudentsController()
        {
            this.data = new StudentsSystemData();
        }

        public IHttpActionResult Get()
        {
            var settings = new JsonSerializerSettings() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii, Formatting = Formatting.Indented };
            var students = data.Students.All().ToList();
            var jsonShits = JsonConvert.SerializeObject(students, settings);
            //// return this.Ok(jsonShits);

            //// If you use postMan can use code bellow but in browser not work.
            return this.Ok<List<Student>>(students);
        }

        public IHttpActionResult Get(int id)
        {
            var student = data.Students.SearchFor(stud => stud.StudentIdentification == id).FirstOrDefault();

            if (student != null)
            {
                //// not work in browser
                return this.Ok<Student>(student);
            }

            return this.NotFound();
        }

        public IHttpActionResult Get(string name)
        {
            var student = data.Students.SearchFor(stud => stud.FirstName.Contains(name) || stud.LastName.Contains(name)).FirstOrDefault();

            if (student != null)
            {
                return this.Ok<Student>(student);
            }

            return this.NotFound();
        }

        public IHttpActionResult Post(Student stud)
        {
            data.Students.Add(stud);
            data.SaveChanges();
            var student = data.Students.SearchFor(st => st.FirstName == stud.FirstName).FirstOrDefault();
            if (student != null)
            {
                return this.Ok(string.Format("Student {0} {1} successfuly added.", student.FirstName, student.LastName));
            }

            return this.InternalServerError();
        }
    }
}