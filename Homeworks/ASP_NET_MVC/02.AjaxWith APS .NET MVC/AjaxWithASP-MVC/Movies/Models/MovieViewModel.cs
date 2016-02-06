using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Movies.Data;
using System.Collections.Generic;

namespace Movies.Models
{
    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> ToViewModel
        {
            get
            {
                return movie => new MovieViewModel()
                {
                    Id = movie.Id,
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

        public static MovieViewModel MapToView(Movie movie)
        {
            Movie[] moviees = new Movie[] { movie };
            return moviees.AsQueryable().Select(ToViewModel).FirstOrDefault();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        [DisplayFormat(NullDisplayText = "Data not available")]
        public string LeadeingMaleRole { get; set; }

        [DisplayFormat(NullDisplayText = "Data not available")]
        public string LeadingFemaleRole { get; set; }

        [DisplayFormat(NullDisplayText = "Data not available")]
        public string Studio { get; set; }

        [DisplayFormat(NullDisplayText = "Data not available")]
        public string StudioAdress { get; set; }
    }
}