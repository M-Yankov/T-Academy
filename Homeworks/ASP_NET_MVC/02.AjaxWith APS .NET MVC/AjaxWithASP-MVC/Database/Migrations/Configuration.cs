namespace Movies.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesDbContext context)
        {
            List<Movie> initialMovies = new List<Movie>()
            {
                new Movie() { Director = "Hops Crop", LeadeingMaleRole = "Actor names", LeadingFemaleRole = "Actress names", Studio = "Sofia", Title = "Undercover", Year = 2011 },
                new Movie() { Director = "Fire Chrome fox", LeadeingMaleRole = "Actor names2", LeadingFemaleRole = "Actress names", Studio = "Plovdiv", Title = "Simpsons", Year = 2014 },
                new Movie() { Director = "Star Terry", LeadeingMaleRole = "Actor names3", LeadingFemaleRole = "Actress names", Studio = "Varna", Title = "Family Guy", Year = 2016, StudioAdress = "Chereshova gora 19" },
                new Movie() { Director = "Michel tom", LeadeingMaleRole = "Cvetan Cvetanov", LeadingFemaleRole = "Lily", Studio = "London", Title = "The Bat Boiko", Year = 2000 },
                new Movie() { Director = "Jerry Gagarin",  Title = "Youtube playlists", Year = 1980 },
                new Movie() { Director = "Siry", LeadeingMaleRole = "Apple", Studio = "Las Vegas", Title = "War Machines", Year = 1978 },
                new Movie() { Director = "Oliver Bond", LeadeingMaleRole = "Klarken", LeadingFemaleRole = "Lora Kena", Studio = "Nevada", Title = "Girls gone wild", Year = 1999, StudioAdress = "Green planes 28 A" },
                new Movie() { Director = "Iron man", LeadeingMaleRole = "Tony stark", Studio = "Stark ind.", Title = "Th boy from the north", Year = 2006 }

            };

            initialMovies.ForEach(movie => context.Movies.AddOrUpdate(m => m.Title, movie));

            context.SaveChanges();
        }
    }
}
