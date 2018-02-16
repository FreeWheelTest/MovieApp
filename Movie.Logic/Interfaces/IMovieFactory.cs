using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Logic.Interfaces
{
    public interface IMovieFactory
    {
        IEnumerable<IMovie> GetMovies();
    }
}
