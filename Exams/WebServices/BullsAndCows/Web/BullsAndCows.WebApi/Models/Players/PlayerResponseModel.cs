namespace BullsAndCows.WebApi.Models.Players
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Models;
    using BullsAndCows.WebApi.Infrastructure;

    public class PlayerResponseModel : IMapFrom<Player> , IHaveCustomMappings
    {
        public string Username { get; set; }

        public int Rank { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Player, PlayerResponseModel>()
                .ForMember(x => x.Username, opts => opts.MapFrom(x => x.Email));
        }
    }
}