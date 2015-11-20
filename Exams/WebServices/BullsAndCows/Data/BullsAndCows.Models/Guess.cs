namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BullsAndCows.Common;

    public class Guess
    {
        public int Id { get; set; }

        [Required]
        public int BullsCount { get; set; }

        [Required]
        public int CowsCount { get; set; }

        [Required]
        [MaxLength(GlobalConstants.NumberLength)]
        [MinLength(GlobalConstants.NumberLength)]
        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public string UserId { get; set; }

        public virtual Player User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
