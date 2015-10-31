namespace ArtistSystem.WebApi.Models
{
    using Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ResponseArtistModel : BaseResponseModel
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

        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name};\nCountry: {this.Country};\nDateOfBirth: {this.DateOfBirth: yyyy.MM.dd}";
        }
    }
}