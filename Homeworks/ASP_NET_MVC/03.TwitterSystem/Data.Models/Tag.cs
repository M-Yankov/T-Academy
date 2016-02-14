namespace Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Tag
    {
        private ICollection<Tweet> tweets;

        public Tag()
        {
            this.tweets = new HashSet<Tweet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.MinLength)]
        [MaxLength(Constants.MaxTagnameLength)]
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get
            {
                return this.tweets;
            }
            set
            {
                this.tweets = value;
            }
        }
    }
}
