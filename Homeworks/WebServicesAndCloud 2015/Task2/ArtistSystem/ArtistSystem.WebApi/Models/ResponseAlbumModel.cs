namespace ArtistSystem.WebApi.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ResponseAlbumModel : BaseResponseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required!")]
        public int Year { get; set; }

        public string ProducerName { get; set; }

        //// auto mapper.

        public override string ToString()
        {
            return $"title: {this.Title};\nYear: {this.Year};\nProducer: {this.ProducerName}";
        }
    }
}