namespace BullsAndCows.UsersService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BullsAndCows.Common;
    using BullsAndCows.Data;
    using Models;

    public class UsersService : IUsersService
    {
        private IBullsAndCowsSystem system;

        public UsersService(IBullsAndCowsSystem serviceSystem)
        {
            this.system = serviceSystem;
        }

        public IEnumerable<UserResponseModel> GetAllUsers(string page)
        {
            int pageFrom = page == null ? 0 : int.Parse(page) - 1;

            return this.system
                .Players
                .All()
                .OrderBy(x => x.UserName)
                .Skip(pageFrom * GlobalConstants.EntitiesPerPage)
                .Take(GlobalConstants.EntitiesPerPage)
                .Select(x => new UserResponseModel
                {
                    Id = x.Id,
                    Username = x.UserName
                })
                .ToList();
        }

        public DetailUserModel GetDetailsForUser(string id)
        {
            var player = this.system
                .Players
                .GetById(id);

            if (player == null)
            {
                throw new EntryPointNotFoundException("Entry with this id not found.");
            }

            return new DetailUserModel()
            {
                Id = player.Id,
                Rank = player.Rank,
                Losses = player.Losses,
                Username = player.UserName,
                Wins = player.Wins
            };
        }
    }
}
