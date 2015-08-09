namespace Santase.Logic.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Santase.Logic.Cards;

    public class Player : IPlayer
    {
        public void AddCard(Card card)
        {
            throw new NotImplementedException();
        }

        public PlayerAction GetTurn(PlayerTurnContext context, IPlayerActionValidater actionValidator)
        {
            throw new NotImplementedException();
        }

        public void EndTurn(PlayerTurnContext context)
        {
            throw new NotImplementedException();
        }
    }
}
