using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

class Animals
{
    static void Main()
    {
        int secretNum = int.Parse(Console.ReadLine()); //1234
        int bulls = int.Parse(Console.ReadLine()); //3
        int goveda = int.Parse(Console.ReadLine());  //0  
        bool found = false;
        //int bullsCopy = bulls;
        //int govedaCopy = goveda;
        int secNumCopy = secretNum;
        
        
        //List<int> guessNums = new List<int>();
        for (int i = 1000; i < 9999; i++)
        {
            secNumCopy = secretNum;
            int currentBulls = 0;
            int currentCows = 0;
            int currentNum = i;
            int digitD = currentNum % 10;    // guess number
            currentNum /= 10;
            int digitC = currentNum % 10;
            currentNum /= 10;
            int digitB = currentNum % 10;
            currentNum /= 10;
            int digitA = currentNum % 10;
            if(digitA == 0|| digitB == 0 || digitC ==0 || digitD == 0)
            {
                continue;
            }
            int guessD = secNumCopy % 10;   // secret number
            secNumCopy /= 10;
            int guessC = secNumCopy % 10;
            secNumCopy /= 10;
            int guessB = secNumCopy % 10;
            secNumCopy /= 10;
            int guessA = secNumCopy % 10;
            #region Find Bulls
            if (digitA == guessA)
            {
                currentBulls++;
                digitA = -1;
                guessA = -12;
            }
            if (digitB == guessB)
            {
                currentBulls++;
                digitB = -1;
                guessB = -12;
            }
            if (digitC == guessC)
            {
                currentBulls++;
                digitC = -1;
                guessC = -12;
            }
            if (digitD == guessD)
            {
                currentBulls++;
                digitD = -1;
                guessD = -12;
            }
            #endregion

            var List = new List<int>();
            if (digitA > 0) List.Add(digitA);
            if (digitB > 0) List.Add(digitB);
            if (digitC > 0) List.Add(digitC);
            if (digitD > 0) List.Add(digitD);
            if(List.Contains(guessA))
            {
                List.Remove(guessA);
                currentCows++;
            }
            if (List.Contains(guessB))
            {
                List.Remove(guessB);
                currentCows++;
            }
            if (List.Contains(guessC))
            {
                List.Remove(guessC);
                currentCows++;
            }
            if (List.Contains(guessD))
            {
                List.Remove(guessD);
                currentCows++;
            }

            //#region cows
            //if(guessA == digitB)
            //{
            //    currentCows++;
            //    guessA = -100;
            //    digitB = -123;
            //}
            //if (guessA == digitC)
            //{
            //    currentCows++;
            //    guessA = -100;
            //    digitC = -123;
            //} 
            //if (guessA == digitD)
            //{
            //    currentCows++;
            //    guessA = -100;
            //    digitD = -123;
            //}
            //if (guessB == digitA)
            //{
            //    currentCows++;
            //    guessB = -100;
            //    digitA = -123;
            //}
            //if (guessB == digitC)
            //{
            //    currentCows++;
            //    guessB = -100;
            //    digitC = -123;
            //} if (guessB == digitD)
            //{
            //    currentCows++;
            //    guessB = -100;
            //    digitD = -123;
            //}
            //if (guessC == digitA)
            //{
            //    currentCows++;
            //    guessC = -100;
            //    digitA = -123;
            //}
            //if (guessC == digitB)
            //{
            //    currentCows++;
            //    guessC = -100;
            //    digitB = -123;
            //}
            //if (guessC == digitD)
            //{
            //    currentCows++;
            //    guessC = -100;
            //    digitD = -123;
            //}
            //if (guessD == digitA)
            //{
            //    currentCows++;
            //    guessD = -100;
            //    digitA = -123;
            //}
            //if (guessD == digitB)
            //{
            //    currentCows++;
            //    guessD = -100;
            //    digitB = -123;
            //}
            //if (guessD == digitC)
            //{
            //    currentCows++;
            //    guessD = -100;
            //    digitC = -123;
            //}
            //#endregion

            if (currentBulls == bulls && currentCows == goveda)
            {
                Console.Write("{0} ", i);
                found = true;
            }
        }
        if(!found)
        {
            Console.WriteLine("No");
        }
        
    }
}