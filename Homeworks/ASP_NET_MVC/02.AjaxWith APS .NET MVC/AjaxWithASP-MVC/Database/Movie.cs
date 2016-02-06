namespace Movies.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        private const int StringMinName = 3;
        private const int StringMaxName = 100;
        private const int MinYear = 1950;
        private const int MaxYear = 2020;

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
