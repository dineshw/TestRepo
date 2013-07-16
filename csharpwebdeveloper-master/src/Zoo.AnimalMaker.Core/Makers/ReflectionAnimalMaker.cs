using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.AnimalMaker.Core.Exceptions;

namespace Zoo.AnimalMaker.Core.Makers
{
    /// <summary>
    /// IMaker implementation for creating animals with .NET reflection.
    /// Description: This will generate the animal dynamically, by getting the list of Animal classes that have implemented the 'IAnimal' interface using reflection followed 
    /// by instantiating the required Animal type. If a new animal type is introduced, simply adding the associated 'Animal' (implementing the 'IAnimal' interface) class 
    /// to the 'Zoo.AnimalMaker.Core' project is sufficient.
    /// </summary>
    public class ReflectionAnimalMaker : IMaker
    {
        /// <summary>
        /// Decides which animal to make based on reflection. 
        /// </summary>
        public IAnimal Make(string name, IAnimalRepository _propertyFeeder)
        {
            try {
                //Retrieve the animal type
                Type animalType = GetAnimalType(name);

                //Instantiate the animal type
                if (animalType != null) {
                    var animalObj = Activator.CreateInstance(animalType, _propertyFeeder);
                    return (IAnimal)animalObj;
                }
            } 
            catch
            {
                //Log the exception details here
            }
            return null;
        }

        /// <summary>
        /// Gets the associated Animal type for the given type name.
        /// Returns null if they type not found.
        /// </summary>
        /// <param name="type">expected animal type as a string</param>
        /// <returns>Type</returns>
        public Type GetAnimalType(string type)
        {
            var animalTypes = GetAllAnimalTypes().ToList();
            var animalType = animalTypes.FirstOrDefault(a => a.Name.ToLower() == type.ToLower());

            if(animalType == null)
            {
                throw new AnimalTypeNotFoundException(type);
            }
            return animalType;
        }

        /// <summary>
        /// Retrieves all the concrete animal types that have implemented the 'IAnimal' interface
        /// </summary>
        /// <returns>List of Types</returns>
        private IEnumerable<Type> GetAllAnimalTypes()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(m => m.IsClass && m.GetInterface("IAnimal") != null && !m.IsAbstract);
        }
    }
}
