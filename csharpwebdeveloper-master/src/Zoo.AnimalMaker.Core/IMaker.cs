using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo.AnimalMaker.Core
{
    /// <summary>
    /// Interface to be implemented by all AnimalMakers. 
    /// E.g AnimalMakers can use different mechanisms to create animals such as using reflection, DI etc.
    /// </summary>
    public interface IMaker
    {
        IAnimal Make(string name, IAnimalRepository _propertyFeeder);
    }
}
