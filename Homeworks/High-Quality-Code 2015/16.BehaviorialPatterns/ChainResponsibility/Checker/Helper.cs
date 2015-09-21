
namespace ChainResponsibility.Checker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChainResponsibility.Utils;
    using ChainResponsibility.Enum;

    public static class Helper
    {
        internal static void SortCardsByFace(IList<Card> cards)
        {
            int currentMin; // = (int)CardFace.Two;
            int nextMin = (int)Face.Ace;
            int indexOfsmaller = -1;

            for (int i = 0; i < cards.Count - 1; i++)
            {
                currentMin = (int)cards[i].Face;
                nextMin = currentMin;

                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (nextMin > (int)cards[j].Face)
                    {
                        nextMin = (int)cards[j].Face;
                        indexOfsmaller = j;
                    }
                }

                if (currentMin > nextMin)
                {
                    Card valueHolder = cards[i];
                    cards[i] = cards[indexOfsmaller];
                    cards[indexOfsmaller] = valueHolder;
                }
            }
        }
    }
}
