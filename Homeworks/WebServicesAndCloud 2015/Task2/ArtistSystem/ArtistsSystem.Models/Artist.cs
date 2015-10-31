namespace ArtistsSystem.Models
{
    using ArtistSystem.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        private ICollection<Song> songs;
        private ICollection<Album> albums;

        public Artist()
        {
            this.songs = new HashSet<Song>();
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLenngth)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.CountryMinLength)]
        [MaxLength(GlobalConstants.CountryMaxLength)]
        public string Country { get; set; }

        [Required]
        public DateTime DataOfBirth { get; set; }

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

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }
    }
}
