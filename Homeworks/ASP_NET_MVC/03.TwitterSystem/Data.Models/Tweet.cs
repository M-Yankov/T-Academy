namespace Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Tweet
    {
        private ICollection<Tag> tags;

        public Tweet()
        {
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.MinLength)]
        [MaxLength(Constants.MaxLength)]
        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags;
            }
            set
            {
                this.tags = value;
            }
        }
    }
}
