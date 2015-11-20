namespace BullsAndCows.WebApi.Models.Games
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using BullsAndCows.Models;
    using BullsAndCows.WebApi.Infrastructure;
    using BullsAndCows.WebApi.Models.Guesses;

    public class GameResponseDetailModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public string YourNumber { get; set; }

        public string YourColor { get; set; }

        public ICollection<GuessResponseModel> YourGuesses { get; set; }

        public ICollection<GuessResponseModel> OpponentGuesses { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, GameResponseDetailModel>()
                         .ForMember(g => g.Red, opts => opts.MapFrom(g => g.RedPlayer.UserName))
                         .ForMember(g => g.Blue, opts => opts.MapFrom(g => g.BluePlayer == null ? "No blue player yet" : g.BluePlayer.UserName))
                         .ForMember(g => g.GameState, opts => opts.MapFrom(g => g.GameState.ToString()));
        }
    }
}