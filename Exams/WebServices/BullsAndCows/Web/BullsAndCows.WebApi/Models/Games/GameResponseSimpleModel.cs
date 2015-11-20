namespace BullsAndCows.WebApi.Models.Games
{
    using System;
    using BullsAndCows.Models;
    using BullsAndCows.WebApi.Infrastructure;

    public class GameResponseSimpleModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Game, GameResponseSimpleModel>()
                         .ForMember(g => g.Red, opts => opts.MapFrom(g => g.RedPlayer.UserName))
                         .ForMember(g => g.Blue, opts => opts.MapFrom(g => g.BluePlayer == null ? "No blue player yet" : g.BluePlayer.UserName))
                         .ForMember(g => g.GameState, opts => opts.MapFrom(g => g.GameState.ToString()));
        }
    }
}