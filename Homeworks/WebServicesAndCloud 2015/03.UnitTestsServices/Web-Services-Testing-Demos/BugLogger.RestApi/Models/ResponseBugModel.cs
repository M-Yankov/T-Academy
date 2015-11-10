namespace BugLogger.RestApi.Models
{
    using System;
    using AutoMapper;
    using BugLogger.DataLayer;
    using BugLogger.RestApi.Infrastructure;

    public class ResponseBugModel : IMapFrom<Bug>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string Text { get; set; }

        public string LogDate { get; set; }

        public void CreateMapping(IConfiguration config)
        {
            config.CreateMap<Bug, ResponseBugModel>()
                .ForMember(x => x.Status, opts => opts.MapFrom(z => z.Status.ToString()))
                .ForMember(x => x.LogDate, opts => opts.MapFrom(z => z.LogDate.Value.Day + "." + z.LogDate.Value.Month + "." + z.LogDate.Value.Year));
        }

        public override bool Equals(object obj)
        {
            var other = obj as ResponseBugModel;
            if (this.Id != other.Id)
            {
                return false;
            }
            else if (this.LogDate != other.LogDate)
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

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}