namespace BullsAndCows.WebApi
{
    using System.Data.Entity;
    using BullsAndCows.Data;
    using BullsAndCows.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initizlize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }
    }
}