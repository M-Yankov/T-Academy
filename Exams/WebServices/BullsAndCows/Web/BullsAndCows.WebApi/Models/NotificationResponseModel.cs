namespace BullsAndCows.WebApi.Models
{
    using System;
    using BullsAndCows.Models;
    using BullsAndCows.WebApi.Infrastructure;

    public class NotificationResponseModel : IMapFrom<Notification>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Notification, NotificationResponseModel>()
                         .ForMember(x => x.Type, o => o.MapFrom(x => x.Type.ToString()))
                         .ForMember(x => x.State, o => o.MapFrom(x => x.State.ToString()));
        }
    }
}