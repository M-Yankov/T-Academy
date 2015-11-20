namespace BullsAndCows.Tests.UnitTests
{
    using System.Collections.Generic;
    using BullsAndCows.WebApi.Controllers;
    using BullsAndCows.WebApi.Models.Games;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class GamesControllerTests
    {
        [TestMethod]
        public void ShouldReturnGamesThatAreFree()
        {
            MyWebApi.Controller<GamesController>()
                .WithResolvedDependencies(Helper.GetGameMockService(), Helper.GetGuessMockService())
                .Calling(c => c.Get(With.Any<int>()))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<GameResponseSimpleModel>>()
                .Passing(c => c.Count == 2);
        }

        [TestMethod]
        public void ShouldRerurnFreeGamesAndGamesThatPlayerAreInForAuthUser()
        {
            MyWebApi.Controller<GamesController>()
                .WithResolvedDependencies(Helper.GetGameMockService(), Helper.GetGuessMockService())
                .WithAuthenticatedUser(user => user.WithUsername("Geri@gmail.com"))
                .Calling(c => c.Get(With.Any<int>()))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<GameResponseSimpleModel>>()
                .Passing(c => c.Count == 3);
        }
    }
}
