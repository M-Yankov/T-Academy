namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ComparingHandsMethods
    {
        private static PokerHandsChecker checker = new PokerHandsChecker();

        internal static int CompareTwoStraightHands(IHand firstHand, IHand secondHand)
        {
            if (checker.IsStraight(firstHand) && checker.IsStraight(secondHand))
            {
                return 1;
            }
            else if (checker.IsStraight(firstHand) && checker.IsStraight(secondHand))
            {
                return -1;
            }

            var firstHandSortedCards = firstHand.Cards;
            var secondHandSortedCards = secondHand.Cards;

            PokerHandsChecker.SortCardsByFace(firstHandSortedCards);
            PokerHandsChecker.SortCardsByFace(secondHandSortedCards);

            int biggestCardFirstHand = (int)firstHandSortedCards[firstHandSortedCards.Count - 1].Face;
            int biggestCardSecondHand = (int)secondHandSortedCards[secondHandSortedCards.Count - 1].Face;

            if (biggestCardFirstHand > biggestCardSecondHand)
            {
                return 1;
            }
            else if (biggestCardFirstHand < biggestCardSecondHand)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        internal static int CompareTwoFlushHands(IHand firstHand, IHand secondHand)
        {
            if (checker.IsFlush(firstHand) && !checker.IsFlush(secondHand))
            {
                return 1;
            }
            else if (!checker.IsFlush(firstHand) && checker.IsFlush(secondHand))
            {
                return -1;
            }

            var firstHandSortedCards = firstHand.Cards;
            var secondHandSortedCards = secondHand.Cards;

            PokerHandsChecker.SortCardsByFace(firstHandSortedCards);
            PokerHandsChecker.SortCardsByFace(secondHandSortedCards);

            for (int i = firstHandSortedCards.Count - 1; i >= 0; i--)
            {
                if ((int)firstHandSortedCards[i].Face > (int)secondHandSortedCards[i].Face)
                {
                    return 1;
                }
                else if ((int)firstHandSortedCards[i].Face < (int)secondHandSortedCards[i].Face)
                {
                    return -1;
                }
            }

            return 0;
        }

        internal static int CompareTwoFullHouseHands(IHand firstHand, IHand secondHand)
        {
            if (checker.IsFullHouse(firstHand) && !checker.IsFullHouse(secondHand))
            {
                return 1;
            }
            else if (!checker.IsFullHouse(firstHand) && checker.IsFullHouse(secondHand))
            {
                return -1;
            }

            Dictionary<CardFace, int> firstHandCounts = new Dictionary<CardFace, int>();
            Dictionary<CardFace, int> secondCardCounts = new Dictionary<CardFace, int>();

            for (int i = 0; i < firstHand.Cards.Count; i++)
            {
                if (firstHandCounts.ContainsKey(firstHand.Cards[i].Face))
                {
                    firstHandCounts[firstHand.Cards[i].Face] += 1;
                }
                else
                {
                    firstHandCounts.Add(firstHand.Cards[i].Face, 1);
                }

                if (secondCardCounts.ContainsKey(secondHand.Cards[i].Face))
                {
                    secondCardCounts[secondHand.Cards[i].Face] += 1;
                }
                else
                {
                    secondCardCounts.Add(secondHand.Cards[i].Face, 1);
                }
            }

            var firstHandThreeKind = 0;
            var firstHandPair = 0;

            var secondHandThreeKind = 0;
            var secondHandPair = 0;

            foreach (var item in firstHandCounts)
            {
                if (item.Value == 3)
                {
                    firstHandThreeKind = (int)item.Key;
                }

                if (item.Value == 2)
                {
                    firstHandPair = (int)item.Key;
                }
            }

            foreach (var item in secondCardCounts)
            {
                if (item.Value == 3)
                {
                    secondHandThreeKind = (int)item.Key;
                }

                if (item.Value == 2)
                {
                    secondHandPair = (int)item.Key;
                }
            }

            if (firstHandThreeKind > secondHandThreeKind)
            {
                return 1;
            }
            else if (firstHandThreeKind < secondHandThreeKind)
            {
                return -1;
            }
            else if (firstHandPair > secondHandPair)
            {
                return 1;
            }
            else if (firstHandPair < secondHandPair)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        internal static int CompareTwoFourOfAKindHands(IHand firstHand, IHand secondHand)
        {
            if (checker.IsFourOfAKind(firstHand) && !checker.IsFourOfAKind(secondHand))
            {
                return 1;
            }
            else if (!checker.IsFourOfAKind(firstHand) && checker.IsFourOfAKind(secondHand))
            {
                return -1;
            }

            int firstHandFourCardsValue = 0;
            int firstHandIOtherCardValue = 0;

            int secondHnadFourCardssValue = 0;
            int secondHandOtherCardValue = 0;

            Dictionary<CardFace, int> firstHandCountsOfSameTypeCards = new Dictionary<CardFace, int>();
            Dictionary<CardFace, int> secondHandCountsOfSameTypeCards = new Dictionary<CardFace, int>();

            for (int i = 0; i < firstHand.Cards.Count; i++)
            {
                if (firstHandCountsOfSameTypeCards.Keys.Contains(firstHand.Cards[i].Face))
                {
                    firstHandCountsOfSameTypeCards[firstHand.Cards[i].Face] += 1;
                }
                else
                {
                    firstHandCountsOfSameTypeCards.Add(firstHand.Cards[i].Face, 1);
                }
            }

            for (int u = 0; u < secondHand.Cards.Count; u++)
            {
                if (secondHandCountsOfSameTypeCards.Keys.Contains(secondHand.Cards[u].Face))
                {
                    secondHandCountsOfSameTypeCards[secondHand.Cards[u].Face] += 1;
                }
                else
                {
                    secondHandCountsOfSameTypeCards.Add(secondHand.Cards[u].Face, 1);
                }
            }

            foreach (var item in firstHandCountsOfSameTypeCards)
            {
                if (item.Value == 4)
                {
                    firstHandFourCardsValue = (int)item.Key;
                }

                if (item.Value == 1)
                {
                    firstHandIOtherCardValue = (int)item.Key;
                }
            }

            foreach (var item in secondHandCountsOfSameTypeCards)
            {
                if (item.Value == 4)
                {
                    secondHnadFourCardssValue = (int)item.Key;
                }

                if (item.Value == 1)
                {
                    secondHandOtherCardValue = (int)item.Key;
                }
            }

            if (firstHandFourCardsValue > secondHnadFourCardssValue)
            {
                return 1;
            }
            else if (firstHandFourCardsValue < secondHnadFourCardssValue)
            {
                return -1;
            }
            else if (firstHandIOtherCardValue > secondHandOtherCardValue)
            {
                return 1;
            }
            else if (firstHandIOtherCardValue < secondHandOtherCardValue)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        internal static int CompareTwoStraightFlushHands(IHand firstHand, IHand secondHand)
        {
            if (checker.IsStraightFlush(firstHand) && !checker.IsStraightFlush(secondHand))
            {
                return 1;
            }
            else if (!checker.IsStraightFlush(firstHand) && checker.IsStraightFlush(secondHand))
            {
                return -1;
            }

            List<ICard> firstHandCards = (List<ICard>)firstHand.Cards;
            List<ICard> secondHandCards = (List<ICard>)secondHand.Cards;

            PokerHandsChecker.SortCardsByFace(firstHandCards);
            PokerHandsChecker.SortCardsByFace(secondHandCards);

            int valueLastCardFromFirstHand = (int)firstHandCards[firstHandCards.Count - 1].Face;
            int valueLastCardFromSecondHand = (int)secondHandCards[secondHandCards.Count - 1].Face;

            if (valueLastCardFromFirstHand > valueLastCardFromSecondHand)
            {
                return 1;
            }
            else if (valueLastCardFromFirstHand < valueLastCardFromSecondHand)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
