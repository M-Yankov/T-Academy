/*Problem 3. Check for a Play Card

    Classical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. 
 * Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise.
 */

using System;


class PlayCard
{
    static void Main()
    {
        while (true) // I use a loop for easy check all values J,Q,K,A,10,8 .... without pressing Ctrl + F5 every time 
        {
            
        
        Console.Write("Enter a symbol: ");
        string card = Console.ReadLine();
        int number= 0 ;
        try                                       
        {
            number = int.Parse(card);
        }
        catch
        {
            SystemException.ReferenceEquals(card, number);
        }
        bool isCard = false;
        if ((number > 1 && number < 11) || card == "A" || card == "Q" || card == "K" || card == "J") 
        {
            isCard = true;
        }
        Console.WriteLine("Character | Valid Card Sign? ");
        Console.WriteLine("{0} \t\t {1}", card, isCard);

        }
    }
}

