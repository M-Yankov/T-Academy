namespace BullsAndCows.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using BullsAndCows.Services.Contracts;
    using BullsAndCows.WebApi.Models.Players;

    public class ScoresController : ApiController
    {
        private IScoreService scoreBoard;

        public ScoresController(IScoreService scoreService)
        {
            this.scoreBoard = scoreService;
        }

        public IHttpActionResult Get()
        {
            var result = scoreBoard.GetTopPlayers().ProjectTo<PlayerResponseModel>().ToList();
            return this.Ok(result);
        }
    }
}