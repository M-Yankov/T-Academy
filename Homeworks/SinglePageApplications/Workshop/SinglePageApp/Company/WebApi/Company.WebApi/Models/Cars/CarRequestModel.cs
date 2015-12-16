namespace Company.WebApi.Models.Cars
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Company.Data.Models;
    using Company.WebApi.Infrastructure;

    public class CarRequestModel : IMapFrom<Car>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [Range(1950, 2020)]
        public int Year { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}