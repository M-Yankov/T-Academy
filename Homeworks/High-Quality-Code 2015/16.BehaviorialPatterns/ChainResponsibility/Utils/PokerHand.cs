namespace ChainResponsibility.Utils
{
    using System;
    using System.Collections.Generic;

    internal class PokerHand
    {
        private List<Card> hand;

        public PokerHand(List<Card> hand)
        {
            this.Cards = hand;
        }

        public List<Card> Cards
        {
            get
            {
                return this.hand;
            }

            private set
            {
                if (value.Count != 5)
                {
                    throw new ArgumentException();
                }

                this.hand = value;
            }
        }
    }
}
