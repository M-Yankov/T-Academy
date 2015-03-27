
namespace P03AnimalHierarhy
{
    using System;
    class Cat : Animal ,ISound
    {
        public Cat(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.PSex = sex;
        }


        public void Talk()
        {
            Console.Beep(5846, 500); // mi
            Console.Write("{0} says: mi -" , this.GetType().Name);
            Console.Beep(4985, 500); // au
            Console.Write(" au");
            Console.Beep(4000, 850); //uuuu
            Console.Write("uUu\n");
        }
    }
}
