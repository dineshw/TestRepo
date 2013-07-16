using Ninject.Modules;
using Zoo.AnimalMaker.Core;
using Zoo.AnimalMaker.Core.Makers;
using Zoo.AnimalMaker.Core.Repositories;

namespace Zoo.AnimalMaker.Factory {

    public class AnimalMakerFactory : NinjectModule {

        /// <summary>
        /// Load & configure Ninject DI bindings required for the solution.
        /// </summary>
        public override void Load() {
            //Bind<IMaker>().To<Maker>();

            //IMaker binding [ options: Maker|ReflectionAnimalMaker ]
            Bind<IMaker>().To<ReflectionAnimalMaker>();  

            //IAnimalRepository binding [ options : DefaultRepository|XmlRepository ]
            Bind<IAnimalRepository>().To<XmlRepository>();  
        }
    }
}
