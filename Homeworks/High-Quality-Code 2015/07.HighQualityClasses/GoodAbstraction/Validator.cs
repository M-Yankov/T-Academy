namespace Abstraction
{
    using System;

    internal abstract class Validator
    {
        internal static void ValidateValue(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Value can't be 0 or negative value!");
            }
        }
    }
}
