namespace ArtistSystem.Data
{
    using ArtistsSystem.Models;
    using ArtistSystem.Data.Migrations;
    using System.Data.Entity;

    public class ArtistSystemContext : DbContext
    {
        public ArtistSystemContext()
            :base("ArtistSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistSystemContext, Configuration>());
        }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }
    }
}
