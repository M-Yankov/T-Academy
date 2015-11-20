namespace BullsAndCows.WebApi.Models.Guesses
{
    using System;
    using System.Linq;
    using AutoMapper;
    using BullsAndCows.Models;
    using BullsAndCows.WebApi.Infrastructure;

    public class GuessResponseModel : IMapFrom<Guess>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int BullsCount { get; set; }

        public int CowsCount { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int GameId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Guess, GuessResponseModel>()
                .ForMember(g => g.UserName, opts => opts.MapFrom(g => g.User.Email));
        }
    }
}