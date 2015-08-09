namespace Poker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private List<ICard> cardsForChecking;

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            cardsForChecking = new List<ICard>();

            foreach (var card in hand.Cards)
            {
                if (!cardsForChecking.Any(c => c.ToString() == card.ToString()))
                {
                    cardsForChecking.Add(card);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            byte lenghtOfFaceValues = 13;
            byte[] counts = new byte[lenghtOfFaceValues];

            for (int i = 0; i < lenghtOfFaceValues; i++)
            {
                counts[i] = (byte)hand.Cards.Count(card => card.Face == (CardFace)i + 2);
            }

            if (counts.Any(count => count == 4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            CardSuit suit = hand.Cards[0].Suit;
            var countOfSameTypeCards = hand.Cards.Count(card => card.Suit == suit);

            return countOfSameTypeCards == 5 ? true : false;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
