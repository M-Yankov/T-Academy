

namespace P03AnimalHierarhy
{
    using System;
    class Frog : Animal , ISound
    {
        public Frog(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.PSex = sex;
        }

        public void Talk()
        {
            Console.Beep(2194, 100);
            Console.Write("{0} says: Kvak" , this.GetType().Name);
            Console.Beep(1500, 150);
            Console.Write("- Kvak \n");
            Console.Beep(999, 99);
        }
    }
}
