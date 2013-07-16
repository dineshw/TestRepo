using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AnimalMaker.Core.Exceptions
{
    public class AnimalTypeNotFoundException : Exception
    {
        public AnimalTypeNotFoundException(string animalType)
            : base(String.Format("'{0}' Animal type not found", animalType))
        {
        }
    }
}
