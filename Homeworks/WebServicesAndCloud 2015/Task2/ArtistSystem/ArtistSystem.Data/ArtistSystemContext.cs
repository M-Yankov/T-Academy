namespace ArtistSystem.Data
{
    using System.Data.Entity;
    using ArtistsSystem.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ArtistSystemContext : IdentityDbContext<User>
    {
        public ArtistSystemContext()
            :base("ArtistSystem", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public static ArtistSystemContext Create()
        {
            return new ArtistSystemContext();
        }
    }
}
