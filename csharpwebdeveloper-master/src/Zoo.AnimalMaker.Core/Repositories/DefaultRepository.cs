namespace Zoo.AnimalMaker.Core.Repositories {
    
    /// <summary>
    /// Simple repository with hard coded values.
    /// This can be used for unit tests.
    /// </summary>
    public class DefaultRepository : IAnimalRepository {

        /// <summary>
        /// FeedProperties implementation
        /// </summary>
        /// <param name="animal">Animal implementation that require it's properties need to be populated</param>
        public void FeedProperties(IAnimal animal)
        {
            var myType = animal.GetType().Name;
            switch (myType.ToLower())
            {
                case "dog":
                    animal.TypeName = "Dog";
                    animal.DailyFeedCost = 15;
                    animal.NumberOfLegs = 4;
                    break;
                case "cat":
                    animal.TypeName = "Cat";
                    animal.DailyFeedCost = 10;
                    animal.NumberOfLegs = 4;
                    break;
            }
        }
    }
}
