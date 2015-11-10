namespace BugLogger.RestApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BugLogger.DataLayer;
    using BugLogger.RestApi.Infrastructure;

    public class SaveBugModel : IMapFrom<Bug>
    {
        public SaveBugModel()
        {
            this.LogDate = DateTime.Now;
            this.Status = SaveStatus.Pending;
        }

        [Required]
        public SaveStatus Status { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Text { get; set; }

        public DateTime? LogDate { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as SaveBugModel;
            if (this.LogDate != other.LogDate)
            {
                return false;
            }
            else if (this.Status != other.Status)
            {
                return false;
            }
            else if (this.Text != other.Text)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}