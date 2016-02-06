namespace Movies
{
    using System.Data.Entity;
    using Movies.Data;
    using Movies.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialze()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Configuration>());
            new MoviesDbContext().Database.Initialize(true);
        }
    }
}