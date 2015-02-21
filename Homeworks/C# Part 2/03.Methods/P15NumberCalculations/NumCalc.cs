/*Problem 15.* Number calculations

    Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
    Use generic method (read in Internet about generic methods in C#).
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NumCalc
{
    static void Main()
    {
        List<float> myFloatList = new List<float> {1.3F , 13.4F ,-3.3F , 1.3455F, 1.085F , 10.94F , 1F};
        List<int> myIntList = new List<int> { 1, 3, 4, 5, 6, 7, 8, 9 };
        List<double> myDoubleList = new List<double> { 3.4, 0.123, 0.33, 1.04, 1.3, 9.99, 1.04 };
        List<decimal> myDecimalList = new List<decimal> { 1.23M, 0.31823M, 2M , 1234.2344M , 5M , 2.917444M , -1.31974M};
        List<sbyte> myByteList = new List<sbyte> { 12, 3, 0, 4, 5, 6, 8, 1, 23, -15, 2, -3, -5, 2, 0 };
        List<ushort> myUshortList = new List<ushort> { 1, 3, 5, 5, 9, 4, 3, 2, 0, 2, 3, 3, 1, 2 };
        List<long> myLongList = new List<long> { 12313567, 31452434, -1352634, 95876, -3469, -762, 12333332 };
    }
    static void AnyType<T>(List<T> list)
    {
        Console.WriteLine("Max is {0}",list.Max());
        Console.WriteLine("Min is {0}", list.Min()); // list.Average(); this not work also for List.Sum()
        
        T sum  =  0; 
        T prduct  = 1;
        T avegage;
        for (int i = 0; i < list.Count; i++)
        {
            sum = sum + list[i];
            prduct *= list[i];
        }
        avegage = sum / list.Count;   // idk how to do it ... but logic is this.
        Console.WriteLine("Average is {0}",avegage);
        Console.WriteLine("Sum is {0}" , sum);
        Console.WriteLine("Product is {0}", prduct);
    }
}


