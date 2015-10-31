using ArtistSystem.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtistsSystem.Models
{
    public class Album
    {
        private ICollection<Artist> artists;
        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLenngth)]
        public string Title { get; set; }

        [Required]
        [Range(GlobalConstants.MinYear, GlobalConstants.MaxYear)]
        public int Year { get; set; }

        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(200)]
        public string Producer { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }
        
        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }
    }
}
