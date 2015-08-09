namespace PokerTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class HandTest
    {
        private static string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private static string[] suits = new string[] { "♥", "♦", "♣", "♠" };

        [Test]
        public void TestSeveralHands()
        {
            IList<ICard> cardCollection = new List<ICard>();
            Random getValue = new Random();

            string randomValue;
            string randomSuit;

            for (int i = 0; i < 5; i++)
            {
                randomValue = values[getValue.Next(0, values.Length - 1)];
                randomSuit = suits[getValue.Next(0, suits.Length - 1)];

                Card current = CardGenerator.Generate(randomValue, randomSuit);

                if (!cardCollection.Contains(current))
                {
                    cardCollection.Add(current);
                }
                else
                {
                    i--;
                }
            }

            Hand cards = new Hand(cardCollection);

            Assert.AreEqual(string.Join(", ", cardCollection), cards.ToString());
        }
    }
}
