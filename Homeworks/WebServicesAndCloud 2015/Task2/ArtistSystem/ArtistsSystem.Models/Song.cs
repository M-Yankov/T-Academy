namespace ArtistsSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using ArtistSystem.Common;

    public class Song
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.TitleMinLength)]
        [MaxLength(GlobalConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Range(GlobalConstants.MinYear, GlobalConstants.MaxYear)]
        public int Year { get; set; }

        [Required]
        [MinLength(GlobalConstants.GenreMinLength)]
        [MaxLength(GlobalConstants.GenreMaxLength)]
        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
