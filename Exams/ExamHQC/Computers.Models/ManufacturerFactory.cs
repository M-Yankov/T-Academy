namespace Computers.Models
{
    using System;
    using Manufacturers;

    public class ManufacturerFactory
    {
        public ComputerFactory GetManufacturer(ManufacturerType type)
        {
            switch (type)
            {
                case ManufacturerType.Dell:
                    return new Dell();
                case ManufacturerType.HP:
                    return new HP();
                case ManufacturerType.Lenovo:
                    return new Lenovo();
                default:
                    throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }
    }
}
