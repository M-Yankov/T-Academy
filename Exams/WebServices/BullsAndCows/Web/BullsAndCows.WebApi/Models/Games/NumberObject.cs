namespace BullsAndCows.WebApi.Models.Games
{
    using System.ComponentModel.DataAnnotations;
    using BullsAndCows.Common;

    public class NumberObject
    {
        [Required]
        [MaxLength(GlobalConstants.NumberLength)]
        [MinLength(GlobalConstants.NumberLength)]
        public string Number { get; set; }
    }
}