using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zoo.AnimalMaker.Core.Animals;

namespace Zoo.AnimalMaker.Core.Makers
{
    /// <summary>
    /// IMaker implementation for creating animals with hard coded names.
    /// History:
    /// [2013-07-15 :Dinesh]: Modified the 'Make' method to be non static as it's now defined in the IMaker interface and designed to be used with DI containers.  
    /// </summary>
    public class Maker : IMaker
    {
        /// <summary>
        /// Decides which animal to make based on a simple logic with the name passed in.
        /// </summary>
        public IAnimal Make(string name, IAnimalRepository _propertyFeeder)
        {
            switch (name)
            {
                case "Dog":
                    return new Dog(_propertyFeeder);
                case "Cat":
                    return new Cat(_propertyFeeder);
                default:
                    return null;
            }
        }
    }
}
