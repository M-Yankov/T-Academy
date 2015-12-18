using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicTacToe.Models;

namespace TicTacToe.Web.Models.ResponseModels
{
    public class ResponseGameModel
    {
        public string Board { get; set; }

        public Guid Id { get ; set; }

        public GameState State { get; set; }

        public string FirstPlayerName { get; set; }

        public string SecondPlayerName { get; set; }
    }
}