
namespace P03AnimalHierarhy
{
    using System;
    class Dog : Animal , ISound
    {
        public Dog(string name , int age , Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.PSex = sex;
        }

        public void Talk()
        {
            Console.Beep(1500, 500);
            Console.Write("{0} says: Dj ", this.GetType().Name);
            Console.Beep(1300, 100);
            Console.Write("- af\n");
            Console.Beep(1000, 200);
        }
    }
}
