using System.Collections.Generic;

namespace MovieApp.Interfaces
{
    public interface IMovieFactory
    {
        IEnumerable<IMovie> GetMovies();
        IEnumerable<IMovie> GetMoviesByCriteria(string criteria);
        IMovie GetMovie(int id);
        bool PutMovie(int id, IMovie movie);
        bool PostMovie(IMovie movie);
        bool DeleteMovie(int id);
    }
}
