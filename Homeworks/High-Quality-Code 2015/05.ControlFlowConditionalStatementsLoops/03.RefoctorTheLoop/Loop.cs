namespace RefoctorTheLoop
{
    using System;

    class Loop
    {
        static void Main()
        {
            int expectedValue = 2;
            bool isValueFound = false;
            int[] numberCollection = new int[6] { 1, 5, 8, 2, 10, 44 };

            for (int number = 0; number < numberCollection.Length; number++)
            {
                Console.WriteLine(numberCollection[number]);

                if (number % 10 == 0 && numberCollection[number] == expectedValue)
                {
                    isValueFound = true;
                }
            }

            // More code here
            if (isValueFound)
            {
                Console.WriteLine("Value Found!");
            }
        }
    }
}
