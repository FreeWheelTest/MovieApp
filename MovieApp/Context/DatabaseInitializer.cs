using System;
using System.Collections.Generic;
using System.Data.Entity;
using MovieApp.Models;

namespace MovieApp.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<MovieAppContext>
    {
        protected override void Seed(MovieAppContext context)
        {
            base.Seed(context);

            var crime = new Genre { Id = 1, Name = "Crime" };
            var drama = new Genre { Id = 2, Name = "Drama" };
            var action = new Genre { Id = 3, Name = "Action" };
            var thriller = new Genre { Id = 4, Name = "Thriller" };

            context.Genres.Add(crime);
            context.Genres.Add(drama);
            context.Genres.Add(action);
            context.Genres.Add(thriller);

            var movies = new List<Movie> {
                new Movie {Id = 1, Title="The Shawshank Redemption", YearOfRelease = 1994, RunningTime = new TimeSpan(0, 2, 22, 0), Genres = new List<Genre>() { crime, drama } },
                new Movie {Id = 2, Title="The Godfather", YearOfRelease = 1972, RunningTime = new TimeSpan(0, 2, 55, 0), Genres = new List<Genre>() { crime, drama } },
                new Movie {Id = 3, Title="The Godfather (Part II)", YearOfRelease = 1974, RunningTime = new TimeSpan(0, 3, 22, 0), Genres = new List<Genre>() { crime, drama } },
                new Movie {Id = 4, Title="The Dark Knight", YearOfRelease = 2008, RunningTime = new TimeSpan(0, 2, 32, 0), Genres = new List<Genre>() { action, crime, thriller } },
                new Movie {Id = 5, Title="12 Angry Men", YearOfRelease = 1957, RunningTime = new TimeSpan(0, 1, 36, 0), Genres = new List<Genre>() { crime, drama } },
            };

            context.Movies.AddRange(movies);

            var users = new List<User> {
                new User { Id = 1, Email="john.appleseed@apple.com" },
                new User { Id = 2, Email="joanna.appleseed@apple.com" },
            };

            context.Users.AddRange(users);

            var ratings = new List<Rating>
            {
                new Rating {MovieId = 1, UserId = 1, Score = 4.8},
                new Rating {MovieId = 1, UserId = 2, Score = 4.5},
                new Rating {MovieId = 2, UserId = 1, Score = 4.5},
                new Rating {MovieId = 2, UserId = 2, Score = 4.1},
                new Rating {MovieId = 3, UserId = 1, Score = 4.4},
                new Rating {MovieId = 3, UserId = 2, Score = 4.6},
                new Rating {MovieId = 4, UserId = 1, Score = 4.8},
                new Rating {MovieId = 4, UserId = 2, Score = 4.2},
                new Rating {MovieId = 5, UserId = 1, Score = 3.9},
                new Rating {MovieId = 5, UserId = 2, Score = 3.6}
            };

            context.Ratings.AddRange(ratings);

            context.SaveChanges();
        }
    }
}