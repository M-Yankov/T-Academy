namespace ChainResponsibility
{
    using System;
    using ChainResponsibility.Checker;
    using ChainResponsibility.Utils;
    using System.Collections.Generic;
    using ChainResponsibility.Enum;

    class Program
    {
        static void Main()
        {
            PokerHand straightFlush = new PokerHand(new List<Card>() 
            {
                new Card(Suit.Clubs, Face.Ace),
                new Card(Suit.Clubs, Face.Ten),
                new Card(Suit.Clubs, Face.King),
                new Card(Suit.Clubs, Face.Jack),
                new Card(Suit.Clubs, Face.Queen),
            });

            PokerHand straight = new PokerHand(new List<Card>()
            {
                new Card(Suit.Spades, Face.Ace),
                new Card(Suit.Clubs, Face.Ten),
                new Card(Suit.Clubs, Face.King),
                new Card(Suit.Diamonds, Face.Jack),
                new Card(Suit.Clubs, Face.Queen),
            });

            PokerHand flush = new PokerHand(new List<Card>()
            {
                new Card(Suit.Clubs, Face.Ace),
                new Card(Suit.Clubs, Face.Ten),
                new Card(Suit.Clubs, Face.Four),
                new Card(Suit.Clubs, Face.Six),
                new Card(Suit.Clubs, Face.Queen),
            });

            PokerHand nothing = new PokerHand(new List<Card>()
            {
                new Card(Suit.Spades, Face.Ace),
                new Card(Suit.Spades, Face.One),
                new Card(Suit.Clubs, Face.Four),
                new Card(Suit.Clubs, Face.Six),
                new Card(Suit.Diamonds, Face.Queen),
            });

            StraightFlushChecker straightFlushChecker = new StraightFlushChecker();
            StraightChecker straightChecker = new StraightChecker();
            FlushChecker flushCkecker = new FlushChecker();

            straightChecker.SetChecker(flushCkecker);
            straightFlushChecker.SetChecker(straightChecker);

            straightFlushChecker.CheckHand(straightFlush);
            straightFlushChecker.CheckHand(straight);
            straightFlushChecker.CheckHand(flush);
            straightFlushChecker.CheckHand(nothing);
        }
    }
}
