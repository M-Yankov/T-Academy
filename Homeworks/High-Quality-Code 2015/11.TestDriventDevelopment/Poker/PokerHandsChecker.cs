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

            //to dO

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

            //to dO

            Dictionary<CardFace, int> values = new Dictionary<CardFace,int>();

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

            if (IsFlush(hand) || IsFourOfAKind(hand))
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

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private static void SortCardsByFace(IList<ICard> cards)
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
