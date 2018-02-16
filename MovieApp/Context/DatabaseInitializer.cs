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

            var genres = new List<Genre>
            {
                new Genre { Name = "Crime" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Action" },
                new Genre { Name = "Thriller" }
            };

            var movies = new List<Movie> {
                new Movie {Title="The Shawshank Redemption", YearOfRelease = 1994, RunningTime = new TimeSpan(0, 2, 22, 0) },
                new Movie {Title="The Godfather", YearOfRelease = 1972, RunningTime = new TimeSpan(0, 2, 55, 0) },
                new Movie {Title="The Godfather (Part II)", YearOfRelease = 1974, RunningTime = new TimeSpan(0, 3, 22, 0) },
                new Movie {Title="The Dark Knight", YearOfRelease = 2008, RunningTime = new TimeSpan(0, 2, 32, 0) },
                new Movie {Title="12 Angry Men", YearOfRelease = 1957, RunningTime = new TimeSpan(0, 1, 36, 0) },
            };

            var users = new List<User> {
                new User { Email="john.appleseed@apple.com" },
                new User { Email="joanna.appleseed@apple.com" },
            };

            var ratings = new List<Rating>
            {
                new Rating {MovieId = 1, UserId = 1, Score = 9},
                new Rating {MovieId = 1, UserId = 2, Score = 7.5},
                new Rating {MovieId = 2, UserId = 1, Score = 8.5},
                new Rating {MovieId = 2, UserId = 2, Score = 7},
                new Rating {MovieId = 3, UserId = 1, Score = 9.4},
                new Rating {MovieId = 3, UserId = 2, Score = 8.6}
            };

            context.Genres.AddRange(genres);
            context.Movies.AddRange(movies);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}