using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IHand forhand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));
            Console.WriteLine(checker.IsTwoPair(hand));
            Console.WriteLine(checker.IsOnePair(hand));
            Console.WriteLine(checker.IsFourOfAKind(forhand));
            Console.WriteLine(checker.IsStraight(forhand));
        }
    }
}
