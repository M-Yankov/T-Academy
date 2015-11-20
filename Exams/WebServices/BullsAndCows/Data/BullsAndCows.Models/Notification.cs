namespace BullsAndCows.Models
{
    using System;
using System.ComponentModel.DataAnnotations;
using BullsAndCows.Common;

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MessageMaxLength)]
        [MinLength(GlobalConstants.MessageMinLength)]
        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public MessageType Type { get; set; }

        public MessageState State { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public string PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}
