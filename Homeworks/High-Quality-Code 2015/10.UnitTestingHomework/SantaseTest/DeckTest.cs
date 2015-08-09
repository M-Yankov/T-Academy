namespace SantaseTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTest
    {
        [Test]
        public void TestDeck()
        {
            Deck cards = new Deck();
            Assert.AreEqual(24, cards.CardsLeft);
        }

        [Test]
        public void TestDeckCountLeft()
        {
            Deck cards = new Deck();
            Card nextCard;

            for (int i = 0; i < 16; i++)
            {
                nextCard = cards.GetNextCard();
            }

            Assert.AreEqual(8, cards.CardsLeft);
        }

        [Test]
        public void TestChangeDeckTrump()
        {
            Card changedTrumpCard = new Card(CardSuit.Heart, CardType.King);
            Deck cards = new Deck();

            cards.ChangeTrumpCard(changedTrumpCard);

            Assert.AreEqual(changedTrumpCard, cards.GetTrumpCard);
            Assert.AreEqual(true, cards.GetTrumpCard.Equals(changedTrumpCard));
        }
        
        [Test]
        [ExpectedException(typeof(InternalGameException))]
        public void TestToThrowDeckWhenNoCard()
        {
            Deck invalidDeck = new Deck();
            byte invalidCoundCards = 32;

            for (int i = 0; i < invalidCoundCards; i++)
            {
                invalidDeck.GetNextCard();
            }
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(24)]
        public void TestCountParameterizedMethods(int drawCards)
        {
            Deck cards = new Deck();
            IList<Card> takedCards = new List<Card>();
            const int DECK_MAX_LENGTH = 24;

            for (int i = 0; i < drawCards; i++)
            {
                Card nextSenselessCard = cards.GetNextCard();
                takedCards.Add(nextSenselessCard);
            }

            Assert.AreEqual(DECK_MAX_LENGTH - drawCards, cards.CardsLeft);
            Assert.AreEqual(drawCards, takedCards.Count);
        }

        [TestCase("♠K")]
        [TestCase("♥9")]
        [TestCase("♦10")]
        [TestCase("♣A")]
        [TestCase("♠Q")]
        [TestCase("♥J")]
        [TestCase("♦10")]
        public void TestChangeWtihDifferentTrumps(string patternForCard)
        {
            Deck cards = new Deck();
            Card trump = GenerateCard(patternForCard);
            cards.ChangeTrumpCard(trump);

            Assert.AreEqual(trump.Type.ToFriendlyString() + trump.Suit.ToFriendlyString(), cards.GetTrumpCard.ToString());
        }

        private static Card GenerateCard(string pattern)
        {
            if (pattern.Length < 2 && 3 > pattern.Length)
            {
                throw new ArgumentOutOfRangeException("Length", "Card pattern must be exactly 2 or 3!");
            }

            CardSuit suit;
            CardType type;

            switch (pattern[0])
            {
                case '♣':
                    suit = CardSuit.Club;
                    break;
                case '♦':
                    suit = CardSuit.Diamond;
                    break;
                case '♥':
                    suit = CardSuit.Heart;
                    break;
                case '♠':
                    suit = CardSuit.Spade;
                    break;
                default:
                    throw new ArgumentException("cardSuit");
            }

            switch (pattern.Substring(1))
            {
                case "9":
                    type = CardType.Nine;
                    break;
                case "10":
                    type = CardType.Ten;
                    break;
                case "J":
                    type = CardType.Jack;
                    break;
                case "Q":
                    type = CardType.Queen;
                    break;
                case "K":
                    type = CardType.King;
                    break;
                case "A":
                    type = CardType.Ace;
                    break;
                default:
                    throw new ArgumentException("cardType");
            }

            return new Card(suit, type);
        }
    }
}
