namespace BigNeibhours
{
    using System;

    public class BigBadNeighbours
    {
        public static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());

            int[] a = new int[15000000];

            for (int i = 0; i < numbersCount; i++)
            {
                int index = int.Parse(Console.ReadLine());
                a[index] = index;
            }

        }
    }
}
