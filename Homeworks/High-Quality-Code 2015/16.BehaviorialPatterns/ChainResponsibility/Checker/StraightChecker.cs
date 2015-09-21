namespace ChainResponsibility.Checker
{
    using ChainResponsibility.Utils;
    using System;

    internal class StraightChecker : BaseHandChecker
    {
        public override void CheckHand(PokerHand pokerHand)
        {
            if (IsStraight(pokerHand))
            {
                Console.WriteLine(String.Format("{0} said: You have a straight!", this.GetType().Name));
            }
            else
            {
                this.NextChecker.CheckHand(pokerHand);
            }
        }

        private bool IsStraight(PokerHand pokerHand)
        {
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
