using System.Collections.Generic;
using System;
using System.Linq;
using MovieApp.Interfaces;
using MovieApp.Models;
using MovieApp.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MovieApp.Factories
{
    public class MovieFactory : IMovieFactory
    {
        private MovieAppContext db = new MovieAppContext();

        public IEnumerable<IMovie> GetMovies()
        {
            return db.Movies.ToList();
        }

        public IEnumerable<IMovie> GetMoviesByCriteria(string title, string genre, int? yearOfRelease)
        {
            var movies = db.Movies.Where(x => x.Title.Contains(title) || x.YearOfRelease == yearOfRelease || x.Genres.Any(z => z.Name.Contains(genre))).ToList();
            
            foreach (var movie in movies)
            {
                var ratings = db.Ratings.Where(x => x.MovieId == movie.Id);
                if (ratings.Count() > 0)
                {
                    movie.AverageRating = (Math.Round(ratings.Average(x => x.Score) * 2, MidpointRounding.AwayFromZero) / 2).ToString("#.#");
                } else
                {
                    movie.AverageRating = "0";
                }
            }

            return movies.Count() > 0 ? movies.OrderBy(x => x.Title).OrderByDescending(x => x.AverageRating) : null;
        }

        public IEnumerable<IMovie> GetHighestTopFive()
        {
            var movies = db.Movies.ToList();
            
            foreach (var movie in movies)
            {

                var ratings = db.Ratings.Where(x => x.MovieId == movie.Id);
                if (ratings.Count() > 0)
                {
                    movie.AverageRating = ratings.Average(x => x.Score).ToString("#.#");
                }
                else
                {
                    movie.AverageRating = "0";
                }
            }

            return movies.Count() > 0 ? movies.OrderBy(x => x.Title).OrderByDescending(x => x.AverageRating).Take(5) : null;
        }

        public IEnumerable<IMovie> GetHighestTopFiveByUser(int userId)
        {
            var users = db.Users.Find(userId);
            if (users != null)
            {

                var movies = db.Movies.ToList();

                foreach (var movie in movies)
                {
                    var ratings = db.Ratings.Where(x => x.MovieId == movie.Id && x.UserId == userId);
                    if (ratings.Count() > 0)
                    {
                        movie.AverageRating = ratings.Average(x => x.Score).ToString("#.#");
                    }
                    else
                    {
                        movie.AverageRating = "0";
                    }
                }

                return movies.Count() > 0 ? movies.OrderBy(x => x.Title).OrderByDescending(x => x.AverageRating).Take(5) : null;
            }
            return null;
        }

        public IMovie GetMovie(int id)
        {
            return db.Movies.Find(id);
        }

        public bool PutMovie(int id, IMovie movie)
        {

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public bool PostMovie(IMovie movie)
        {
            db.Movies.Add(new Movie { Title = movie.Title, YearOfRelease = movie.YearOfRelease });
            db.SaveChanges();

            return true;
        }

        public bool DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return false;
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return true;
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            Dispose(disposing);
        }
    }
}
