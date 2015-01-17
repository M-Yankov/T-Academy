/*Problem 16.** Bit Exchange (Advanced)

    Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
    The first and the second sequence of bits may not overlap.
*/

using System;


class BitsAdvaced
{
    static void Main()
    {
        uint number = 0;
        Console.Write("First enter an integer number: ");
        try //it's like if() 
        {
            number = uint.Parse(Console.ReadLine());
        }
        catch (System.OverflowException)//if you enter number big than int32 type. Program will show "Error Overflow". Like else
        {
            Console.WriteLine("Error Overflow ");
            return;
        }
        Console.WriteLine("Your number in bits = " + Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.Write("Enter first position(index of bit): ");
        int firstPosition = int.Parse(Console.ReadLine());
        Console.Write("Enter second position(index of bit): ");
        int secondPosition = int.Parse(Console.ReadLine());
        Console.Write("How many bits to be changed? ");
        int range = int.Parse(Console.ReadLine());
        if (Math.Abs(firstPosition - secondPosition) < range || firstPosition + range > 31 || secondPosition + range > 31) 
        {
            Console.WriteLine("Overlapping or out of range...");
            return;
        }
        uint mask = (uint)Math.Pow(2, range) - 1;//creating perfect mask for entered range.
        //Console.WriteLine(mask+"and it's presentation in bits: " + Convert.ToString(mask,2));
        uint result1 = (uint)number & (mask << firstPosition); //catch bits group from first position and assign to 'result1'
        result1 >>= firstPosition;
        uint result2 = (uint)number & (mask << secondPosition); //catch bits group from second position and assign to 'result2'
        result2 >>= secondPosition;
        number &= ~(mask << firstPosition);//set value 0 from first postion
        number &= ~(mask << secondPosition); //set value 0 from second position
        number |= (result2 << firstPosition);
        number |= (result1 << secondPosition);
        Console.WriteLine("Your number after exchange " + number);
        
    }
}

