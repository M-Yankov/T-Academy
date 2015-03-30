/*Problem 5. 64 Bit array

    Define a class BitArray64 to hold 64 bit values inside an ulong value.
    Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
*/
namespace P05BitArray64
{
    using System;
    class TestingBitArray
    {
        static void Main()
        {
            BitArray64 myArr = new BitArray64(5);
            BitArray64 myArr2 = new BitArray64(5);
            DateTime date = DateTime.Now;
            for (int i = 0; i < myArr.Lenght; i++)
            {
                myArr[i] = (ulong)(Math.Pow(date.Second, i) + i); //....
                myArr2[i] = myArr[i];
            }
            Console.WriteLine("Array #1: {0}", myArr);
            Console.WriteLine("Hash code of array: {0}", myArr.GetHashCode());
            Console.WriteLine("Array #2: {0}", myArr2);
            Console.WriteLine("Are they equal? A: {0}" , myArr.Equals(myArr2));
            for (int i = 0; i < myArr2.Lenght; i++)
            {
                myArr2[i] += 1;
            }
            Console.WriteLine("After change values. Are they equal {0}", myArr == myArr2);
            Console.WriteLine(); // results depends on current second from system Datetime :D
        }
    }
}
