namespace BugLogger.DataLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Text { get; set; }

        public DateTime? LogDate { get; set; }
    }
}
