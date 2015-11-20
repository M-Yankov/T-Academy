namespace BullsAndCows.WebApi.Models.Games
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BullsAndCows.Common;

    public class GameRequestModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(GlobalConstants.MaxStringName)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.NumberLength)]
        [MinLength(GlobalConstants.NumberLength)]
        public string Number { get; set; }
    }
}