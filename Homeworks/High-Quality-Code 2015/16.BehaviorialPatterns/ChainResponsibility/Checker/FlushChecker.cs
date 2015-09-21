
namespace ChainResponsibility.Checker
{
    using System;
    using System.Linq;
    using ChainResponsibility.Utils;
    using ChainResponsibility.Enum;

    internal class FlushChecker: BaseHandChecker
    {
        public override void CheckHand(PokerHand pokerHand)
        {
            if (IsFlush(pokerHand))
            {
                Console.WriteLine(String.Format("{0} said: You have a flush!", this.GetType().Name));
            }
            else
            {
                Console.WriteLine(String.Format("{0} said: You need more methods on the chain!", this.GetType().Name));
            }
        }

        private bool IsFlush(PokerHand pokerHand)
        {
            Suit cardSuit = pokerHand.Cards[0].Suit;
            int countOfCardsWithEqualSuits = pokerHand.Cards.Count(card => card.Suit == cardSuit);

            if (countOfCardsWithEqualSuits != 5)
            {
                return false;
            }

            return true;
        } 
    }
}
