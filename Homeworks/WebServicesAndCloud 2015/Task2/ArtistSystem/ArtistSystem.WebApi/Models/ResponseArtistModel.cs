namespace ArtistSystem.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using ArtistsSystem.Models;
    using AutoMapper;
    using Common;
    using Infrastructure;

    public class ResponseArtistModel : BaseResponseModel, IMapFrom<Artist>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLenngth)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required!")]
        [MinLength(GlobalConstants.CountryMinLength)]
        [MaxLength(GlobalConstants.CountryMaxLength)]
        public string Country { get; set; }

        public DateTime DataOfBirth { get; set; }

        public ICollection<string> SongNames { get; set; }

        public ICollection<string> AlbumNames { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name};\nCountry: {this.Country};\nDateOfBirth: {this.DataOfBirth: yyyy.MM.dd}";
        }

        public void CreateMapping(IConfiguration config)
        {
            config.CreateMap<Artist, ResponseArtistModel>()
                .ForMember(x => x.SongNames, opts => opts.MapFrom(a => a.Songs.Select(xz => xz.Title)))
                .ForMember(x => x.AlbumNames, opts => opts.MapFrom(a => a.Albums.Select(sz => sz.Title).ToList()));
        }
    }
}