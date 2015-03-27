
namespace P03AnimalHierarhy
{
    using System;

    class Kitten : Cat , ISound
    {
        public Kitten(string name, int age , Sex sex)
            :base(name ,age , sex)
        {
            if (sex == Sex.male)
            {
                throw new ArgumentException("Kitten must be female! "); // to check if it works
            }
        }

        

        
    }
}
