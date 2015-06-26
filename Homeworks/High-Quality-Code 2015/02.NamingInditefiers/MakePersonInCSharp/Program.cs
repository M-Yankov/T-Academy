// Task 2. Make_Чуек in C
//    Refactor the following examples to produce code with well-named C# identifiers.
namespace MakePersonInCSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // I can't resolve what name must be this class. So "Program" should work
    public class Program
    {
        enum Gender { male, female }

        class Person
        {
            public Gender gender { get; set; }
            public string name { get; set; }
            public int age { get; set; }
        }

        public void MakePerson(int ageOfPerson)
        {
            Person citizien = new Person();
            citizien.age = ageOfPerson;
            if (ageOfPerson % 2 == 0)
            {
                citizien.name = "Tony Montana";
                citizien.gender = Gender.male;
            }
            else
            {
                citizien.name = "Halle Berry";
                citizien.gender = Gender.female;
            }
        }

        // There is an error without `Main` method.
        static void Main() { }
    }
}
