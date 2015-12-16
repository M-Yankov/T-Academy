namespace Company.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

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

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
