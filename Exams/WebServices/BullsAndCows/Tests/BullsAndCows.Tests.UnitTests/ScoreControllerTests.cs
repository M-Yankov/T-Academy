namespace BullsAndCows.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BullsAndCows.Common;
    using BullsAndCows.WebApi.Controllers;
    using BullsAndCows.WebApi.Models.Players;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class ScoreControllerTests
    {
        [TestMethod]
        public void ScoresTest()
        {
            MyWebApi.Controller<ScoresController>()
                    .WithResolvedDependencies(Helper.GetScoreMockService())
                    .Calling(c => c.Get())
                    .ShouldReturn()
                    .Ok()
                    .WithResponseModelOfType<List<PlayerResponseModel>>()
                    .Passing(c => 
                    {
                        Assert.AreEqual(GlobalConstants.EntitiesPerPage, c.Count);
                    });
        }

        [TestMethod]
        public void ScoresResultShouldBeSortedByRank()
        {
            MyWebApi.Controller<ScoresController>()
                    .WithResolvedDependencies(Helper.GetScoreMockService())
                    .Calling(c => c.Get())
                    .ShouldReturn()
                    .Ok()
                    .WithResponseModelOfType<List<PlayerResponseModel>>()
                    .Passing(c =>
                    {
                        Assert.IsTrue(this.CheckCollectionIsSorted(c));
                    });
        }

        private bool CheckCollectionIsSorted(IList<PlayerResponseModel> players)
        {
            for (int i = 1; i < players.Count; i++)
            {
                if (players[i - 1].Rank < players[i].Rank)
                {
                    return false;
                }
            }

            return true;
        }
    }
}