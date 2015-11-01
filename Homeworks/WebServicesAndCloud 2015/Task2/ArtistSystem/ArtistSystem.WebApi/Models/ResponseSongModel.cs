namespace ArtistSystem.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using ArtistsSystem.Models;
    using AutoMapper;
    using Common;
    using Infrastructure;

    public class ResponseSongModel : BaseResponseModel, IMapFrom<Song>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        [MinLength(GlobalConstants.TitleMinLength, ErrorMessage = "Not enoght title length!" )]
        [MaxLength(GlobalConstants.TitleMaxLength, ErrorMessage = "Max length of Title!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required!")]
        [Range(GlobalConstants.MinYear, GlobalConstants.MaxYear, ErrorMessage ="Year does not in range!")]
        public int Year { get;  set; }

        [Required(ErrorMessage = "Genre is required!")]
        [MinLength(GlobalConstants.GenreMinLength , ErrorMessage = "Not enough length for genre!")]
        [MaxLength(GlobalConstants.GenreMaxLength, ErrorMessage = "Too much symbols!" )]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Artist is required!")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "AlbumId is required!")]
        public int AlbumId { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public override string ToString()
        {
            return $"title: {this.Title};\nYear: {this.Year};\nGenre: {this.Genre}";
        }

        public void CreateMapping(IConfiguration config)
        {
            config.CreateMap<Song, ResponseSongModel>()
                .ForMember(s => s.ArtistName, opts => opts.MapFrom(rs => rs.Artist.Name))
                .ForMember(s => s.AlbumName, opts => opts.MapFrom(rs => rs.Album.Title));
        }
    }
}