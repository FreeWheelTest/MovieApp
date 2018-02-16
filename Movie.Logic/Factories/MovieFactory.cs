using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Logic.Interfaces;

namespace MovieApp.Factories
{
    public class MovieFactory : IMovieFactory
    {
        public IEnumerable<IMovie> GetMovies()
        {
            return null;
        }
    }
}
