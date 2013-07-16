using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AnimalMaker.Core.Dto {

    /// <summary>
    /// DTO to be used when Animal data is fetched from database, xml etc.
    /// </summary>
    public class Animal {
        public string TypeName { get; set; }
        public int NumberOfLegs { get; set; }
        public decimal DailyFeedCost { get; set; }
    }
}
