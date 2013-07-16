using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo.AnimalMaker.Core
{
    /// <summary>
    /// Interface to be implemented by all Repositories that will be used to populate IAnimal properties 
    /// E.g Repositories can use different mechanisms and data sources to feed property values such as from a database, XML file or even from a text file.
    /// </summary>
    public interface IAnimalRepository
    {
        void FeedProperties(IAnimal animal);
    }
}
