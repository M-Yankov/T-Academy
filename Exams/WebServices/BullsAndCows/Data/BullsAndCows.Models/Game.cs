namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BullsAndCows.Common;

    public class Game
    {
        private ICollection<Guess> guesss;
        private ICollection<Notification> notifications; 
            
        public Game()
        {
            this.guesss = new HashSet<Guess>();
            this.notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxStringName)]
        public string Name { get; set; }

        [ForeignKey("RedPlayer")]
        [MaxLength(GlobalConstants.MaxStringName)]
        public string RedPlayerId { get; set; }

        public virtual Player RedPlayer { get; set; }

        [ForeignKey("BluePlayer")]
        [MaxLength(GlobalConstants.MaxStringName)]
        public string BluePlayerId { get; set; }

        public virtual Player BluePlayer { get; set; }

        [Required]
        [MaxLength(GlobalConstants.NumberLength)]
        [MinLength(GlobalConstants.NumberLength)]
        public string RedPlayerGuessNumber { get; set; }

        [MaxLength(GlobalConstants.NumberLength)]
        [MinLength(GlobalConstants.NumberLength)]
        public string BluePlayerGuessNumber { get; set; }

        public virtual ICollection<Guess> Guess
        {
            get
            {
                return this.guesss;
            }

            set
            {
                this.guesss = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }
    }
}