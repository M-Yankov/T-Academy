namespace ChainResponsibility.Checker
{
    using ChainResponsibility.Enum;
    using ChainResponsibility.Utils;
    using System;
    using System.Linq;

    internal class StraightFlushChecker : BaseHandChecker
    {
        public override void CheckHand(PokerHand pokerHand)
        {
            if (IsRoyal(pokerHand))
            {
                Console.WriteLine(String.Format("{0} said: You have a straight flush!", this.GetType().Name));
            }
            else
            {
                //Console.WriteLine("Someone else must check for it.");
                this.NextChecker.CheckHand(pokerHand);
            }
        }

        private bool IsRoyal(PokerHand pokerHand)
        {
            Suit cardSuit = pokerHand.Cards[0].Suit;
            int countOfCardsWithEqualSuits = pokerHand.Cards.Count(card => card.Suit == cardSuit);

            if (countOfCardsWithEqualSuits != 5)
            {
                return false;
            }

            var copyOfHand = pokerHand.Cards;
            Helper.SortCardsByFace(copyOfHand);

            int startNumber = (int)copyOfHand[0].Face;

            // it can be done with for
            foreach (Card card in copyOfHand)
            {
                if ((int)card.Face != startNumber)
                {
                    return false;
                }

                startNumber++;
            }

            return true;
        }
    }
}
