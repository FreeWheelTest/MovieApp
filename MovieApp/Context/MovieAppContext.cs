using System.Data.Entity;

namespace MovieApp.Context
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext() : base("name=MovieAppContext")
        {
        }

        public DbSet<Models.Genre> Genres { get; set; }
        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Rating> Ratings { get; set; }
    }
}
