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

        // FullHouse 3 kind + pair
        [Test]
        public void TestFullHouse()
        {
            IList<ICard> fullHouse = new List<ICard>();

            fullHouse.Add(new Card(CardFace.Four, CardSuit.Clubs));
            fullHouse.Add(new Card(CardFace.Four, CardSuit.Spades));
            fullHouse.Add(new Card(CardFace.Six, CardSuit.Hearts));
            fullHouse.Add(new Card(CardFace.Four, CardSuit.Hearts));
            fullHouse.Add(new Card(CardFace.Six, CardSuit.Clubs));

            Hand cards = new Hand(fullHouse);
            Assert.IsTrue(this.checker.IsFullHouse(cards));
        }

        // Straight flush
        [Test]
        public void TestStraightFlush()
        {
            IList<ICard> straightFlush = new List<ICard>();

            straightFlush.Add(new Card(CardFace.Six, CardSuit.Clubs));
            straightFlush.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            straightFlush.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            straightFlush.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            straightFlush.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand cards = new Hand(straightFlush);

            Assert.IsTrue(this.checker.IsFlush(cards));
            Assert.IsTrue(this.checker.IsStraight(cards));
            Assert.IsTrue(this.checker.IsStraightFlush(cards));
        }

        // Compare full house /to do other situations
        [Test]
        public void TestCompareStraightFlushes()
        {
            Hand firstHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
            });

            Hand secondHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
            });

            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        // Compare straight flush / To do: Test more cases!
        [Test]
        public void TestCompareStraightFlush()
        {
            Hand firstHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });

            Hand secondHand = new Hand(new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
            });

            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }
        
        // Compare FourOfaKiind test other cases
        [Test]
        public void TestFourOfAkind()
        {
            Hand firstHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            Hand secondHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
            });

            Assert.IsTrue(this.checker.IsFourOfAKind(firstHand) && this.checker.IsFourOfAKind(secondHand));
            Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
        }

        // Compare Flush
        [Test]
        public void TestFlush()
        {
            Hand firstHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            Hand secondHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
            });

            Assert.IsTrue(this.checker.IsFlush(firstHand) && this.checker.IsFlush(secondHand));
            Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
        }

        // Compare Straights
        [Test]
        public void TestStraight()
        {
            Hand firstHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            Hand secondHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            Assert.IsTrue(this.checker.IsStraight(firstHand) && this.checker.IsStraight(secondHand));
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }
    }
}
