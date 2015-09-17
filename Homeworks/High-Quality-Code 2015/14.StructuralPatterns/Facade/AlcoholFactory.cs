namespace Facade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Facade
    /// </summary>
    public class AlcoholFactory
    {
        private IList<Container> containers;
        private readonly int defaultSize = 16;
        private readonly int beerGradus = 4;

        private AlcoholFactory()
        {
            containers = new List<Container>();
            this.DefaultInitialization();
        }

        public static AlcoholFactory CreateInstance()
        {
            return new AlcoholFactory();
        }

        public void DrinkGetBigBeer()
        {
            Container bigContainer = containers.FirstOrDefault(cont => cont.Type == ContainerType.Keg);

            if (bigContainer == null)
            {
                Console.WriteLine("Big beers is empty");
                return;
            }

            MachineWashContainer.WashContainer(bigContainer);
            FillContainer.WithAlcohol(new Beer(beerGradus), bigContainer);

            Console.WriteLine("You just got a keg of beer! Nice one!");
            containers.Remove(bigContainer);
        }

        public void DrinkBottleBeer()
        {
            Container glass = containers.FirstOrDefault(cont => cont.Type == ContainerType.Glass);

            if (glass == null)
            {
                Console.WriteLine("There are no beer bottles");
                return;
            }

            MachineWashContainer.WashContainer(glass);
            FillContainer.WithAlcohol(new Beer(beerGradus), glass);

            Console.WriteLine("Cheers! Here you are you beer;");
            containers.Remove(glass);
        }

        public void JustGiveSomeBeer()
        {
            if (containers.Count != 0)
            {
                Container justBeer = containers[0];
                MachineWashContainer.WashContainer(justBeer);
                FillContainer.WithAlcohol(new Beer(beerGradus), justBeer);
                Console.WriteLine("Take a fast cold beer :)");
                containers.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("There are no any beer :(");
            }

        }

        private void DefaultInitialization()
        {
            ContainerType[] types = new ContainerType[] { ContainerType.Can, ContainerType.Glass, ContainerType.Plastic, ContainerType.Keg };
            double liters = 0;
            for (int i = 0, typeIndex = 0; i < defaultSize; i++, typeIndex++)
            {
                if (typeIndex >= types.Length)
                {
                    typeIndex = 0;
                }

                switch (typeIndex)
                {
                    case 0:
                        liters = 0.56;
                        break;
                    case 1:
                        liters = 0.5;
                        break;
                    case 2:
                        liters = 2;
                        break;
                    case 3:
                        liters = 5;
                        break;
                    default:
                        break;
                }

                containers.Add(new Container((types[typeIndex]), liters));
            }
        }
    }
}
