using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.AnimalMaker.Core;
using Zoo.AnimalMaker.Factory;

namespace AnimalLibraryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTester tester = new MyTester();
            IAnimal dog = tester.MakeAnimal("dog");
            IAnimal cat = tester.MakeAnimal("cat");

            Console.WriteLine(dog.GetType().ToString());
            Console.WriteLine(dog.TypeName);
            Console.WriteLine(dog.DailyFeedCost);
            Console.WriteLine(dog.NumberOfLegs);
            Console.WriteLine(cat.GetType().ToString());
            Console.WriteLine(cat.TypeName);
            Console.WriteLine(cat.DailyFeedCost);
            Console.WriteLine(cat.NumberOfLegs);
            Console.ReadLine();
        }

        public class MyTester
        {
            private IMaker _animalMaker;
            private IAnimalRepository _propertyFeeder;

            public MyTester()
            {
                SetUpAnimalLibrary();
            }

            private void SetUpAnimalLibrary()
            {
                //Configures the ninject kernel with DI bindings
                IKernel kernel = new StandardKernel();
                kernel.Load(new AnimalMakerFactory());

                //Instantiate an AnimalMaker using the ninject kernal.
                _animalMaker = kernel.Get<IMaker>();

                //Instantiate an PropertyFeeder using the ninject kernal.
                _propertyFeeder = kernel.Get<IAnimalRepository>();
            }

            public IAnimal MakeAnimal(string animaltype)
            {
                var animal = _animalMaker.Make(animaltype, _propertyFeeder);
                return animal;
            }
        }
    }
}
