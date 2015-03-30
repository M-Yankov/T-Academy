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
            DateTime date = DateTime.Now;
            for (int i = 0; i < myArr.Lenght; i++)
            {
                myArr[i] = (ulong)(Math.Pow(date.Second, i) + i ); //....
            }
            
            foreach (ulong item in myArr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(); // results depends on current second from system Datetime :D
        }
    }
}
