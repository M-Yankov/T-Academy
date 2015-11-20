namespace BullsAndCows.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BullsAndCows.Common;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Contracts;
    using BullsAndCows.WebApi.Models.Games;
    using BullsAndCows.WebApi.Models.Guesses;
    using Microsoft.AspNet.Identity;

    public class GamesController : ApiController
    {
        private IGameService gameService;
        private IGuessService guessService;

        public GamesController(IGameService gameService, IGuessService guessService)
        {
            this.gameService = gameService;
            this.guessService = guessService;
        }

        public IHttpActionResult Get(int page = 1)
        {
            IQueryable<GameResponseSimpleModel> result =
                this.gameService
                .GetAllGames(page - 1)
                .ProjectTo<GameResponseSimpleModel>();

            if (this.User.Identity.IsAuthenticated)
            {
                // All freeGames and that games user is in it. private
                result = result.Where(x => x.GameState == GameState.WaitingForOpponent.ToString() || x.Blue == this.User.Identity.Name || x.Red == this.User.Identity.Name);
            }
            else
            {
                // All freeGames for not authorized
                result = result.Where(x => x.GameState == GameState.WaitingForOpponent.ToString());
            }

            return this.Ok(result.ToList());
        }

        [Authorize]
        [Route("api/games/{id}")]
        public IHttpActionResult GetGameDetails(int id)
        {
            Game resultGame =
                this.gameService
                .GetGameDetails(id);

            if (resultGame == null)
            {
                return this.NotFound();
            }

            var currentUserID = this.User.Identity.GetUserId();
            if (!(currentUserID == resultGame.RedPlayerId || currentUserID == resultGame.BluePlayerId))
            {
                return this.StatusCode(HttpStatusCode.Forbidden);
            }

            GameResponseDetailModel response = Mapper.Map<GameResponseDetailModel>(resultGame);

            //// Separate Method
            if (currentUserID == resultGame.RedPlayerId)
            {
                response.YourNumber = resultGame.RedPlayerGuessNumber;
                response.YourColor = PlayerColor.Red.ToString();
                response.YourGuesses = resultGame.Guess.Where(g => g.UserId == currentUserID).AsQueryable().ProjectTo<GuessResponseModel>().ToList();
                response.OpponentGuesses = resultGame.Guess.Where(g => g.UserId == resultGame.BluePlayerId).AsQueryable().ProjectTo<GuessResponseModel>().ToList();
            }
            else
            {
                response.YourNumber = resultGame.BluePlayerGuessNumber;
                response.YourColor = PlayerColor.Blue.ToString();
                response.YourGuesses = resultGame.Guess.Where(g => g.UserId == currentUserID).AsQueryable().ProjectTo<GuessResponseModel>().ToList();
                response.OpponentGuesses = resultGame.Guess.Where(g => g.UserId == resultGame.RedPlayerId).AsQueryable().ProjectTo<GuessResponseModel>().ToList();
            }

            return this.Ok(response);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(GameRequestModel newGame)
        {
            if (!AreNumbersValid(newGame.Number))
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                return this.BadRequest("Numbers must be unique!");
            }

            Game createdGame = this.gameService.CreateNewGame(newGame.Name, newGame.Number, this.User.Identity.GetUserId());

            GameResponseSimpleModel responseGame = Mapper.Map<GameResponseSimpleModel>(createdGame);
            return this.Created(this.Request.RequestUri.AbsoluteUri, responseGame);
        }

        [Authorize]
        [Route("api/games/{id}")]
        [HttpPut]
        public IHttpActionResult Put(NumberObject join, int id)
        {
            if (join == null)
            {
                return this.BadRequest("Provide a 4 digit unique number to join in game!");
            }

            if (!AreNumbersValid(join.Number))
            {
                return this.BadRequest(string.Format("Numbers must be unique with length {0}!", GlobalConstants.NumberLength));
            }

            Game game = this.gameService.GetGameDetails(id);
            var response = new HttpResponseMessage();
            if (game == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Content = new StringContent(string.Format("Game with id {0} not found!", id));
                return this.ResponseMessage(response);
            }

            if (game.GameState != GameState.WaitingForOpponent)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("This game is running or finished. You can't join!");
                return this.ResponseMessage(response);
            }

            if (game.RedPlayerId == this.User.Identity.GetUserId())
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("You already joined is this game!");
                return this.ResponseMessage(response);
            }

            this.gameService.JoinGame(game, this.User.Identity.GetUserId(), join.Number, this.User.Identity.Name);

            return this.Ok(string.Format("You joined game \"{0}\"", game.Name));
        }

        [Authorize]
        [HttpPost]
        [Route("api/games/{id}/guess")]
        public IHttpActionResult Guess(NumberObject guess, int id)
        {
            if (guess == null)
            {
                return this.BadRequest("Po seriozno!");
            }

            if (!AreNumbersValid(guess.Number))
            {
                return this.BadRequest(string.Format("Numbers must be unique with length {0}!", GlobalConstants.NumberLength));
            }

            Game game = this.gameService.GetGameDetails(id);
            var response = new HttpResponseMessage();
            if (game == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Content = new StringContent(string.Format("Game with id {0} not found!", id));
                return this.ResponseMessage(response);
            }

            var playerId = this.User.Identity.GetUserId();
            if (!(game.BluePlayerId == playerId || game.RedPlayerId == playerId))
            {
                response.StatusCode = HttpStatusCode.Forbidden;
                response.Content = new StringContent("You are not allowed to make guess in this game");
                return this.ResponseMessage(response);
            }

            string currentPlayer = game.BluePlayerId == playerId ? "BluePlayerTurn" : "RedPlayerTurn";
            if (currentPlayer != game.GameState.ToString())
            {
                if (game.GameState == GameState.Finished)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    response.Content = new StringContent("Game Is Finished!");
                    return this.ResponseMessage(response);
                }

                response.StatusCode = HttpStatusCode.Forbidden;
                response.Content = new StringContent("It's not your turn!");
                return this.ResponseMessage(response);
            }

            string numberToGuess = game.BluePlayerId == playerId ? game.RedPlayerGuessNumber : game.BluePlayerGuessNumber;
            Guess guessFromServer = this.guessService.MakeGuess(guess.Number, numberToGuess, playerId, game.Id);
            GuessResponseModel responseGuess = Mapper.Map<GuessResponseModel>(guessFromServer);

            return this.Ok(responseGuess);
        }

        private bool AreNumbersValid(string numbers)
        {
            if (numbers == null)
            {
                return false;
            }

            if (numbers.Length != GlobalConstants.NumberLength)
            {
                return false;
            }

            var result = new HashSet<char>();
            for (int i = 0; i < numbers.Length; i++)
            {
                result.Add(numbers[i]);
            }

            if (result.Count != GlobalConstants.NumberLength)
            {
                return false;
            }

            return true;
        }
    }
}