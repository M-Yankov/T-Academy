namespace Company.WebApi
{
    using System.Data.Entity;
    using Company.Data;
    using Company.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultDbContext, Configuration>());
        }
    }
}