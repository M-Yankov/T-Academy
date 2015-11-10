namespace BugLogger.DataLayer
{
    using System.Data.Entity;
    using BugLogger.DataLayer.Migrations;

    public class BugLoggerDbContext : DbContext
    {
        public BugLoggerDbContext()
            : base("BugLoggerDb")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }
    }
}
