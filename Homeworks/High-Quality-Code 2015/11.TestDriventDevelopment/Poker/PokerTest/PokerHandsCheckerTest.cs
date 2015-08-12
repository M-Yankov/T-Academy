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

        // One pair
        [Test]
        public void TestOnePair()
        {
            IList<ICard> onePair = new List<ICard>();

            onePair.Add(new Card(CardFace.King, CardSuit.Clubs));
            onePair.Add(new Card(CardFace.Seven, CardSuit.Spades));
            onePair.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            onePair.Add(new Card(CardFace.Ten, CardSuit.Spades));
            onePair.Add(new Card(CardFace.Ace, CardSuit.Spades));

            Hand cards = new Hand(onePair);
            Assert.IsTrue(this.checker.IsOnePair(cards));
        }

        [Test]
        public void TestFakeOnePair()
        {
            IList<ICard> threeOfAKind = new List<ICard>();

            threeOfAKind.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            threeOfAKind.Add(new Card(CardFace.Seven, CardSuit.Spades));
            threeOfAKind.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            threeOfAKind.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            threeOfAKind.Add(new Card(CardFace.Ace, CardSuit.Spades));

            Hand cards = new Hand(threeOfAKind);
            Assert.IsFalse(this.checker.IsOnePair(cards));
        }

        // Two pairs
        [Test]
        public void TestTwopairs()
        {
            IList<ICard> twoPairs = new List<ICard>();

            twoPairs.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            twoPairs.Add(new Card(CardFace.Seven, CardSuit.Spades));
            twoPairs.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            twoPairs.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            twoPairs.Add(new Card(CardFace.King, CardSuit.Spades));

            Hand cards = new Hand(twoPairs);
            Assert.IsTrue(this.checker.IsTwoPair(cards));
        }

        [Test]
        public void TestTwoFakePairs()
        {
            IList<ICard> twoFakePairs = new List<ICard>();

            twoFakePairs.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            twoFakePairs.Add(new Card(CardFace.Seven, CardSuit.Spades));
            twoFakePairs.Add(new Card(CardFace.Ace, CardSuit.Spades));
            twoFakePairs.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            twoFakePairs.Add(new Card(CardFace.Seven, CardSuit.Clubs));

            Hand cards = new Hand(twoFakePairs);
            Assert.IsFalse(this.checker.IsTwoPair(cards));
        }

        // Three of a kind
        [Test]
        public void TestThreeOfAKind()
        {
            IList<ICard> threeKind = new List<ICard>();

            threeKind.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            threeKind.Add(new Card(CardFace.Ace, CardSuit.Spades));
            threeKind.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            threeKind.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            threeKind.Add(new Card(CardFace.Queen, CardSuit.Hearts));

            Hand cards = new Hand(threeKind);
            Assert.IsTrue(this.checker.IsThreeOfAKind(cards));
        }

        [Test]
        public void TestFakeThreeOfAKind()
        {
            IList<ICard> threeKind = new List<ICard>();

            threeKind.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            threeKind.Add(new Card(CardFace.Ace, CardSuit.Spades));
            threeKind.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            threeKind.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            threeKind.Add(new Card(CardFace.Queen, CardSuit.Clubs));

            Hand cards = new Hand(threeKind);
            Assert.IsFalse(this.checker.IsThreeOfAKind(cards));
        }

        // Strait
        [Test]
        public void TestStrait()
        {
            IList<ICard> strait = new List<ICard>();

            strait.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            strait.Add(new Card(CardFace.Queen, CardSuit.Spades));
            strait.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            strait.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            strait.Add(new Card(CardFace.King, CardSuit.Clubs));

            Hand cards = new Hand(strait);
            Assert.IsTrue(this.checker.IsStraight(cards));
        }

        [Test]
        public void TestAnotherStrait()
        {
            IList<ICard> strait = new List<ICard>();

            strait.Add(new Card(CardFace.Four, CardSuit.Clubs));
            strait.Add(new Card(CardFace.Five, CardSuit.Spades));
            strait.Add(new Card(CardFace.Six, CardSuit.Hearts));
            strait.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            strait.Add(new Card(CardFace.Eight, CardSuit.Clubs));

            Hand cards = new Hand(strait);
            Assert.IsTrue(this.checker.IsStraight(cards));
        }

        // IsHighCard 
        [Test]
        public void TestHighCard()
        {
            IList<ICard> differentFaces = new List<ICard>();

            differentFaces.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            differentFaces.Add(new Card(CardFace.Five, CardSuit.Spades));
            differentFaces.Add(new Card(CardFace.Six, CardSuit.Hearts));
            differentFaces.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            differentFaces.Add(new Card(CardFace.Eight, CardSuit.Clubs));

            Hand cards = new Hand(differentFaces);
            Assert.IsTrue(this.checker.IsHighCard(cards));
        }

        [Test]
        public void TestFakeHighCard()
        {
            IList<ICard> differentFaces = new List<ICard>();

            differentFaces.Add(new Card(CardFace.Four, CardSuit.Clubs));
            differentFaces.Add(new Card(CardFace.Five, CardSuit.Spades));
            differentFaces.Add(new Card(CardFace.Six, CardSuit.Hearts));
            differentFaces.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            differentFaces.Add(new Card(CardFace.Eight, CardSuit.Clubs));

            Hand cards = new Hand(differentFaces);
            Assert.IsFalse(this.checker.IsHighCard(cards));
        }
    }
}
