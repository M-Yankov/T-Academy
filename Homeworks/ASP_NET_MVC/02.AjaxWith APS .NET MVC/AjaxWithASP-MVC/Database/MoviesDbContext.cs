namespace Movies.Data
{
    using System.Data.Entity;

    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            :base("MoviesDataBase")
        {
        }

        public IDbSet<Movie> Movies { get; set; } 
    }
}
