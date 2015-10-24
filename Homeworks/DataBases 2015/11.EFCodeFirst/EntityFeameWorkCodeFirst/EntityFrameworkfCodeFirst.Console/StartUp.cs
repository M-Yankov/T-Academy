namespace EntityFrameworkfCodeFirst.Console
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using EntityFeameWorkCodeFirst.Models;
    using EntityFrameWorkCodeFirst.Data;
    using EntityFrameWorkCodeFirst.Data.Migrations;

    public class StartUp
    {
        public static void Main()
        {
            SchoolDbContext connection = new SchoolDbContext();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDbContext, Configuration>());
            connection.Configuration.AutoDetectChangesEnabled = false;

            int count = connection.Courses.Count();
            Console.WriteLine(count);

            Course course = connection.Courses.FirstOrDefault();
            IList<Course> courses = new List<Course>();
            courses.Add(course);
            Student pesho = new Student { Name = "Petar Ivanov", FacultyNumber = 1243, IsDrunk = true, Courses = courses };
            connection.Students.Add(pesho);

            connection.SaveChanges();
        }
    }
}