namespace ArtistSystem.Data
{
    using ArtistsSystem.Models;

    public interface IArtistSystemData
    {
        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        int SaveChanges();
    }
}
