namespace MovieApp.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using MovieApp.Interfaces;
    using MovieApp.Factories;
	
    public class DefaultRegistry : Registry {

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            For<IRatingFactory>().Use<RatingFactory>();
            For<IMovieFactory>().Use<MovieFactory>();
            For<IUserFactory>().Use<UserFactory>();
        }
    }
}