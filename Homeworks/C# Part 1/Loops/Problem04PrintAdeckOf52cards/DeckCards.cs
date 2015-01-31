/*Problem 4. Print a Deck of 52 Cards

    Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). 
 *  The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
        The card faces should start from 2 to A.
        Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.
 * Note: You may use the suit symbols instead of text.
*/

using System;



class DeckCards
{
    static void Main()
    {
        string[] cards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] text = new string[] { "\u2660,", "\u2663,", "\u2665,", "\u2666", };                        // I use symbols instead of text. It's string text but it looks on the console like symbol.
        for (int i = 0; i <= cards.Length -1 ; i++)
        {
            for (int k = 0; k <= text.Length - 1; k++) 
            {
                Console.Write(cards[i] + " of " + text[k] + " ");
            }
            Console.WriteLine();
        }
    }
}

