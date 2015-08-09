namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Poker;

    internal static class CardGenerator
    {
        internal static Card Generate(string faceInput, string suit)
        {
            CardFace face;
            CardSuit cardSuit;

            switch (faceInput)
            {
                case "2":
                    face = CardFace.Two;
                    break;
                case "3":
                    face = CardFace.Three;
                    break;
                case "4":
                    face = CardFace.Four;
                    break;
                case "5":
                    face = CardFace.Five;
                    break;
                case "6":
                    face = CardFace.Six;
                    break;
                case "7":
                    face = CardFace.Seven;
                    break;
                case "8":
                    face = CardFace.Eight;
                    break;
                case "9":
                    face = CardFace.Nine;
                    break;
                case "10":
                    face = CardFace.Ten;
                    break;
                case "J":
                    face = CardFace.Jack;
                    break;
                case "Q":
                    face = CardFace.Queen;
                    break;
                case "K":
                    face = CardFace.King;
                    break;
                case "A":
                    face = CardFace.Ace;
                    break;
                default:
                    face = CardFace.Ace;
                    break;
            }

            switch (suit)
            {
                case "♥":
                    cardSuit = CardSuit.Hearts;
                    break;
                case "♦":
                    cardSuit = CardSuit.Diamonds;
                    break;
                case "♣":
                    cardSuit = CardSuit.Clubs;
                    break;
                case "♠":
                    cardSuit = CardSuit.Spades;
                    break;
                default:
                    cardSuit = CardSuit.Spades;
                    break;
            }

            return new Card(face, cardSuit);
        }
    }
}
