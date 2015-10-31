namespace ArtistSystem.WebApi
{
    using Data.Migrations;
    using Data;
    using System.Data.Entity;

    public static class DataBaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistSystemContext, Configuration>());
            ArtistSystemContext.Create().Database.Initialize(true);
        }
    }
}