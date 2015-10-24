namespace EntityFeameWorkCodeFirst.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int ID { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }

        public int StudentID { get; set; }

        public virtual Student Student { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
    }
}