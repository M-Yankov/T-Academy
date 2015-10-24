namespace EntityFrameWorkCodeFirst.Data
{
    using System.Data.Entity;
    using EntityFeameWorkCodeFirst.Models;

    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
            : base("School")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }
    }
}
