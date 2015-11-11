namespace BugLogger.RestApi.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using BugLogger.DataLayer;
    using BugLogger.RestApi.Infrastructure;

    public class SaveBugModel : IMapFrom<Bug>
    {
        private DateTime? date;

        public SaveBugModel()
        {
            //// Default values are not set here because object from the request body doesn't match properties.
            //// this.LogDate = DateTime.Now;
            //// this.Status = SaveStatus.Pending;
        }

        [DefaultValue(SaveStatus.Pending)]
        public SaveStatus Status { get; set; }

        [Required(ErrorMessage = "Text of the bug cannot be null or empty.")]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Text { get; set; }

        public DateTime? LogDate 
        {
            get 
            {
                if (this.date == null)
                {
                    this.date = DateTime.Now;
                }

                return this.date;
            }

            set
            {
                if (value == null)
                {
                    this.date = DateTime.Now;
                }
                else
                {
                    this.date = value;
                }
            }
        }

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