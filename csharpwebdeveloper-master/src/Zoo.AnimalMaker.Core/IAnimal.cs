using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo.AnimalMaker.Core
{
    /// <summary>
    /// Interface to be implemented by all animal types
    /// </summary>
    public interface IAnimal
    {
        string TypeName { get; set; }
        int NumberOfLegs { get; set; }
        decimal DailyFeedCost { get; set; }
    }
}
