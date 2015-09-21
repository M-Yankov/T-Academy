namespace ChainResponsibility.Utils
{
    using ChainResponsibility.Enum;
    using System;
    using System.Linq;

    internal class Card
    {
        private Suit suit;
        private Face face;

        public Card(Suit suit, Face number)
        {
            this.Suit = suit;
            this.Face = number;
        }


        public Face Face
        {
            get 
            {
                return face; 
            }
            set
            { 
                this.face = value; 
            }
        }



        public Suit Suit
        {
            get 
            {
                return suit; 
            }
            set
            { 
                this.suit = value; 
            }
        }

    }
}
