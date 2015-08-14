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
            if (!IsValidHand(hand) || !IsFlush(hand) || !IsStraight(hand))
            {
                return false;
            }

            return true;
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
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) || IsStraight(hand) || IsStraightFlush(hand))
            {
                return false;
            }

            Dictionary<CardFace, int> values = new Dictionary<CardFace, int>();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (values.ContainsKey(hand.Cards[i].Face))
                {
                    values[hand.Cards[i].Face] += 1;
                }
                else
                {
                    values.Add(hand.Cards[i].Face, 1);
                }
            }

            if (values.Count != 2)
            {
                return false;
            }

            int countOfpairs = values.Values.Count(val => val == 2);
            int countOfthreeKind = values.Values.Count(val => val == 3);

            if (countOfpairs == 1 && countOfthreeKind == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (!IsValidHand(hand))
            {
                return false;
            }

            List<ICard> sortedCollection = new List<ICard>();
            sortedCollection = (List<ICard>)hand.Cards;
            SortCardsByFace(sortedCollection);

            int valueOfFirst = (int)sortedCollection[0].Face;

            if (valueOfFirst > (int)CardFace.Ten)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if ((int)sortedCollection[i].Face != valueOfFirst + i)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) || IsFourOfAKind(hand) || IsFullHouse(hand) || IsStraight(hand) || IsStraightFlush(hand))
            {
                return false;
            }

            byte lenghtOfFaceValues = 13;
            byte[] counts = new byte[lenghtOfFaceValues];

            for (int i = 0; i < lenghtOfFaceValues; i++)
            {
                counts[i] = (byte)hand.Cards.Count(card => card.Face == (CardFace)i + 2);
            }

            if (counts.Any(count => count == 3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) || IsFourOfAKind(hand) || IsThreeOfAKind(hand) ||
                IsFullHouse(hand) || IsStraight(hand) || IsStraightFlush(hand))
            {
                return false;
            }

            Dictionary<CardFace, int> values = new Dictionary<CardFace, int>();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (values.ContainsKey(hand.Cards[i].Face))
                {
                    values[hand.Cards[i].Face] += 1;
                }
                else
                {
                    values.Add(hand.Cards[i].Face, 1);
                }
            }

            int countOfpairs = values.Values.Count(val => val == 2);

            if (countOfpairs == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) || IsFourOfAKind(hand) || IsThreeOfAKind(hand) ||
                IsTwoPair(hand) || IsFullHouse(hand) || IsStraight(hand) || IsStraightFlush(hand))
            {
                return false;
            }

            Dictionary<CardFace, int> values = new Dictionary<CardFace, int>();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (values.ContainsKey(hand.Cards[i].Face))
                {
                    values[hand.Cards[i].Face] += 1;
                }
                else
                {
                    values.Add(hand.Cards[i].Face, 1);
                }
            }

            int countOfpairs = values.Values.Count(val => val == 2);

            if (countOfpairs == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsFlush(hand) || IsFourOfAKind(hand) || IsThreeOfAKind(hand) || IsOnePair(hand) ||
                IsTwoPair(hand) || IsFullHouse(hand) || IsStraight(hand) || IsStraightFlush(hand))
            {
                return false;
            }

            byte lenghtOfFaceValues = 13;
            byte[] counts = new byte[lenghtOfFaceValues];

            for (int i = 0; i < lenghtOfFaceValues; i++)
            {
                counts[i] = (byte)hand.Cards.Count(card => card.Face == (CardFace)i + 2);
            }

            if (counts.Any(count => count > 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Compares two poker hands
        /// </summary>
        /// <param name="firstHand"></param>
        /// <param name="secondHand"></param>
        /// <returns>
        /// 1: first hand is bigger,
        /// -1: second hand is bigger,
        /// 0: the two hands are equal;
        /// </returns>
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new InvalidOperationException("Some of hands are invalid!");
            }

            // Straight flush
            if (this.IsStraightFlush(firstHand) || this.IsStraightFlush(secondHand))
            {
                return ComparingHandsMethods.CompareTwoStraightFlushHands(firstHand, secondHand);
            }

            // FOur of a kind
            if (this.IsFourOfAKind(firstHand) || this.IsFourOfAKind(secondHand))
            {
                return ComparingHandsMethods.CompareTwoFourOfAKindHands(firstHand, secondHand);
            }

            // Full house
            if (this.IsFullHouse(firstHand) || this.IsFullHouse(secondHand))
            {
                return ComparingHandsMethods.CompareTwoFullHouseHands(firstHand, secondHand);
            }

            // Flush
            if (this.IsFlush(firstHand) || this.IsFlush(secondHand))
            {
                return ComparingHandsMethods.CompareTwoFlushHands(firstHand, secondHand);
            }

            // Straight
            if (this.IsStraight(firstHand) || this.IsStraight(secondHand))
            {
                return ComparingHandsMethods.CompareTwoStraightHands(firstHand, secondHand);
            }

            throw new NotImplementedException("High card is at last");
        }

        internal static void SortCardsByFace(IList<ICard> cards)
        {
            int currentMin; // = (int)CardFace.Two;
            int nextMin = (int)CardFace.Ace;
            int indexOfsmaller = -1;

            for (int i = 0; i < cards.Count - 1; i++)
            {
                currentMin = (int)cards[i].Face;
                nextMin = currentMin;

                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (nextMin > (int)cards[j].Face)
                    {
                        nextMin = (int)cards[j].Face;
                        indexOfsmaller = j;
                    }
                }

                if (currentMin > nextMin)
                {
                    ICard valueHolder = cards[i];
                    cards[i] = cards[indexOfsmaller];
                    cards[indexOfsmaller] = valueHolder;
                }
            }
        }
    }
}
