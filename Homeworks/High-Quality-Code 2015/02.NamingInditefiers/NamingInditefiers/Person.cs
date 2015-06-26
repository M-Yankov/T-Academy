/*Task 1. class_123 in C

    Refactor the following examples to produce code with well-named C# identifiers.*/

namespace NamingInditefiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Person
    {
        const int MAX_COUNT = 6;

        class Male
        {
            // This method must have pucblic access modifier.
            public void CheckWeight(bool hasTraining)
            {
                string weightInKg = hasTraining.ToString();
                Console.WriteLine(weightInKg);
            }
        }

        public static void Main()
        {
            Person.Male veryStrongPerson = new Person.Male();
            veryStrongPerson.CheckWeight(true);
        }
    }
}
