namespace ArtistSystem.WebApi
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public static class DataBaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistSystemContext, Configuration>());
            ArtistSystemContext.Create().Database.Initialize(true);
        }
    }
}