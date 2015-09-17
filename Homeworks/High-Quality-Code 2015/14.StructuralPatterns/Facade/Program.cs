

namespace Facade
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string dashes = new string('-', 4);
            var beerFactory = AlcoholFactory.CreateInstance();
            beerFactory.DrinkBottleBeer();
            Console.WriteLine(string.Format("{0} {1} {2}", dashes, "I need more beer!", dashes));
            beerFactory.DrinkGetBigBeer();
            for (int i = 0; i < 15; i++)
            {
                beerFactory.JustGiveSomeBeer();
            }
        }
    }
}
