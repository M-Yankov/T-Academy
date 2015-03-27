/*Problem 3. Animal hierarchy

    Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
    Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
*/

namespace P03AnimalHierarhy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Media;
    using System.Text;

    class MainMethod
    {
        public static Animal[] zooPark;
        static void Main()
        {
            Cat tommy = new Cat("Tommy" ,2 ,Sex.male);
            Dog sharo = new Dog("Sharo" , 3 ,Sex.male);
            Frog princess = new Frog("Afrodita" , 5 , Sex.female);
            Kitten milka = new Kitten("Milka" , 4 , Sex.female);
            TomCat tom = new TomCat("Tom" , 1 , Sex.male);
            zooPark = new Animal[] { tommy, sharo ,princess , milka , tom};    // <-- Is this an abstract ? A: maybe calling a array is possible ...

            
            foreach (var animal in zooPark)
            {
                Console.WriteLine(animal);
                switch (animal.GetType().Name)
                {
                    case "Dog":
                        Dog doggy = animal as Dog;
                        doggy.Talk();
                        break;
                    case "Cat":
                        Cat catty = animal as Cat;
                        catty.Talk();
                        break;
                    case "Frog":
                        Frog frogie = animal as Frog;
                        frogie.Talk();
                        break;
                    default:
                        break;
                }
            }
            CalculateAverageAge();
            Console.WriteLine("\n\r\n\rTo see that condition for male checking of kitten and TOmcat works");
            // See implemented method below
            CheckSexAnimal();


        }
        public static void CalculateAverageAge()
        {
            var averageAge = zooPark.Average(x => x.Age);
            Console.WriteLine("Average age of animals is {0}",averageAge);
        }

        public static void CheckSexAnimal()
        {
            try
            {
                Kitten myPet = new Kitten("Jessica", 3, Sex.male);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
            // So it works .... 

        }
    }
}
