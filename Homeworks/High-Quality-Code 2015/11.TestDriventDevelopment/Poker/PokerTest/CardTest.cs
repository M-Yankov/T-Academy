namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class CardTest
    {
        [TestCase("A", "♥")]
        [TestCase("2", "♦")]
        [TestCase("10", "♠")]
        [TestCase("6", "♥")]
        [TestCase("2", "♥")]
        [TestCase("7", "♣")]
        [TestCase("J", "♣")]
        [TestCase("J", "♠")]
        [TestCase("A", "♦")]
        [TestCase("10", "♣")]
        [TestCase("9", "♥")]
        [TestCase("Q", "♠")]
        [TestCase("A", "♣")]
        [TestCase("10", "♦")]
        [TestCase("K", "♥")]
        public void TestCadrs(string typeValue, string suit)
        {
            Card randomCard = CardGenerator.Generate(typeValue, suit);
            Assert.AreEqual(typeValue + suit, randomCard.ToString());
        }
    }
}
