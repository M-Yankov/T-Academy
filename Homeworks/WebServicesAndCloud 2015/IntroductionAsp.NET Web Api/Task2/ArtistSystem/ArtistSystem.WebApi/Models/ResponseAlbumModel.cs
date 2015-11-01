namespace ArtistSystem.WebApi.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using ArtistsSystem.Models;
    using AutoMapper;
    using Infrastructure;

    public class ResponseAlbumModel : BaseResponseModel, IMapFrom<Album>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required!")]
        public int Year { get; set; }

        public string ProducerName { get; set; }

        public int CountOfSongs { get; set; }

        public ICollection<string> ArtistsNames { get; set; }

        public override string ToString()
        {
            return $"title: {this.Title};\nYear: {this.Year};\nProducer: {this.ProducerName}";
        }

        public void CreateMapping(IConfiguration config)
        {
            config.CreateMap<Album, ResponseAlbumModel>()
                .ForMember(x => x.ProducerName, opts => opts.MapFrom(x => x.Producer))
                .ForMember(x => x.CountOfSongs, opts => opts.MapFrom(sx => sx.Songs.Count))
                .ForMember(x => x.ArtistsNames, opts => opts.MapFrom(r => r.Artists.Select(a => a.Name).ToList()));
        }
    }
}