namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Poker;

    // Not all cases are tested sorry.
    [TestFixture]
    public class PokerHandsCheckerTest
    {
        private PokerHandsChecker checker = new PokerHandsChecker();

        // IsValidHand
        [Test]
        public void TestValidHand()
        {
            IList<ICard> cardCollection = new List<ICard>()
            {
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };

            Hand playerHand = new Hand(cardCollection);
            Assert.IsTrue(this.checker.IsValidHand(playerHand));
        }

        [Test]
        public void TestInValidHand()
        {
            IList<ICard> cardCollection = new List<ICard>()
            {
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };

            Hand playerHand = new Hand(cardCollection);
            Assert.IsFalse(this.checker.IsValidHand(playerHand));
        }

        [Test]
        public void TestInValidHandLessCards()
        {
            IList<ICard> cardCollection = new List<ICard>()
            {
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };

            Hand playerHand = new Hand(cardCollection);
            Assert.IsFalse(this.checker.IsValidHand(playerHand));
        }

        // Flush
        [Test]
        public void TestANormalFlush()
        {
            IList<ICard> cardFlushCollection = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
            };

            Hand playerHand = new Hand(cardFlushCollection);

            Assert.IsTrue(this.checker.IsFlush(playerHand));
        }

        [Test]
        public void TestANotFlushHand()
        {
            IList<ICard> cardFlushCollection = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
            };

            Hand playerHand = new Hand(cardFlushCollection);

            Assert.IsFalse(this.checker.IsFlush(playerHand));
        }

        [Test]
        public void TestANotFlushHandAgain()
        {
            IList<ICard> cardFlushCollection = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
            };

            Hand playerHand = new Hand(cardFlushCollection);

            Assert.IsFalse(this.checker.IsFlush(playerHand));
        }

        // Four of a kind
        [Test]
        public void TestAllPossibleFourOfAKindHands()
        {
            IList<ICard> fourOfAKindCollection = new List<ICard>();
            byte countOfAllValues = 13;
            byte countOfAllKinds = 4;
            Hand playerHand;
            List<bool> results = new List<bool>();
            int faceOfAdditionalCard;

            for (int i = 0; i < countOfAllValues; i++)
            {
                faceOfAdditionalCard = i;

                for (int j = 1; j <= countOfAllKinds; j++)
                {
                    fourOfAKindCollection.Add(new Card((CardFace)i + 2, (CardSuit)j));
                }

                if (faceOfAdditionalCard + 3 > 14)
                {
                    faceOfAdditionalCard = 2;
                }

                fourOfAKindCollection.Add(new Card((CardFace)faceOfAdditionalCard + 3, CardSuit.Hearts));
                playerHand = new Hand(fourOfAKindCollection);

                results.Add(this.checker.IsFourOfAKind(playerHand));

                fourOfAKindCollection.Clear();
            }

            byte countOfAllTrueResults = (byte)results.Count(res => res == true);

            Assert.AreEqual(results.Count, countOfAllTrueResults);
        }

        [Test]
        public void TestAllPossibleFourOfAKindHandsAddingDifferentCardFirst()
        {
            IList<ICard> fourOfAKindCollection = new List<ICard>();
            byte countOfAllValues = 13;
            byte countOfAllKinds = 4;
            Hand playerHand;
            List<bool> results = new List<bool>();
            int faceOfAdditionalCard;

            for (int i = 0; i < countOfAllValues; i++)
            {
                faceOfAdditionalCard = i;

                if (faceOfAdditionalCard + 3 > 14)
                {
                    faceOfAdditionalCard = 2;
                }

                fourOfAKindCollection.Add(new Card((CardFace)faceOfAdditionalCard + 3, CardSuit.Hearts));

                for (int j = 1; j <= countOfAllKinds; j++)
                {
                    fourOfAKindCollection.Add(new Card((CardFace)i + 2, (CardSuit)j));
                }

                playerHand = new Hand(fourOfAKindCollection);

                results.Add(this.checker.IsFourOfAKind(playerHand));

                fourOfAKindCollection.Clear();
            }

            byte countOfAllTrueResults = (byte)results.Count(res => res == true);

            Assert.AreEqual(results.Count, countOfAllTrueResults);
        }
    }
}
