namespace Movies.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Data;

    public class MovieCreateModel
    {
        private const int StringMinName = 3;
        private const int StringMaxName = 100;
        private const int MinYear = 1950;
        private const int MaxYear = 2020;

        public static Expression<Func<Movie, MovieCreateModel>> ToCreateModel
        {
            get
            {
                return movie => new MovieCreateModel()
                {
                    Director = movie.Director,
                    Title = movie.Title,
                    Studio = movie.Studio,
                    StudioAdress = movie.StudioAdress,
                    Year = movie.Year,
                    LeadeingMaleRole = movie.LeadeingMaleRole,
                    LeadingFemaleRole = movie.LeadingFemaleRole
                };
            }
        }

        public static MovieCreateModel MapToCreateModel(Movie movie)
        {
            Movie[] moviees = new Movie[] { movie };
            return moviees.AsQueryable().Select(ToCreateModel).FirstOrDefault();
        }

        public void TransferValuesTo(Movie movieToMap)
        {
            movieToMap.Director = this.Director;
            movieToMap.Title = this.Title;
            movieToMap.Studio = this.Studio;
            movieToMap.StudioAdress = this.StudioAdress;
            movieToMap.Year = this.Year;
            movieToMap.LeadeingMaleRole = this.LeadeingMaleRole;
            movieToMap.LeadingFemaleRole = this.LeadingFemaleRole;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(StringMinName)]
        [MaxLength(StringMaxName)]
        public string Title { get; set; }

        [Required]
        [MinLength(StringMinName)]
        [MaxLength(StringMaxName)]
        public string Director { get; set; }

        [Required]
        [Range(MinYear, MaxYear)]
        public int Year { get; set; }

        [MinLength(StringMinName)]
        [MaxLength(StringMaxName)]
        public string LeadeingMaleRole { get; set; }

        [MinLength(StringMinName)]
        [MaxLength(StringMaxName)]
        public string LeadingFemaleRole { get; set; }

        [MinLength(StringMinName)]
        [MaxLength(StringMaxName)]
        public string Studio { get; set; }

        [MinLength(StringMinName)]
        [MaxLength(StringMaxName)]
        public string StudioAdress { get; set; }
    }
}