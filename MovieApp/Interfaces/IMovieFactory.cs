using System.Collections.Generic;

namespace MovieApp.Interfaces
{
    public interface IMovieFactory
    {
        IEnumerable<IMovie> GetMovies();
        IEnumerable<IMovie> GetMoviesByCriteria(string criteria, string genre, int? yearOfRelease);
        IEnumerable<IMovie> GetHighestTopFive();
        IEnumerable<IMovie> GetHighestTopFiveByUser(int userId);
        IMovie GetMovie(int id);
        bool PutMovie(int id, IMovie movie);
        bool PostMovie(IMovie movie);
        bool DeleteMovie(int id);
    }
}
