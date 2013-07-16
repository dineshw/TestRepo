using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AnimalMaker.Core.Animals
{
    /// <summary>
    /// Abstraction for all animal types containing the common properties and their property feeding mechanism
    /// </summary>
    public abstract class AbstractAnimal : IAnimal
    {

        public string TypeName { get; set; }
        public int NumberOfLegs { get; set; }
        public decimal DailyFeedCost { get; set; }

        private readonly IAnimalRepository _animalRepository;

        protected AbstractAnimal(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
            _animalRepository.FeedProperties(this);
        }
    }
}
