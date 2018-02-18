using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MovieApp.Interfaces;
using MovieApp.Models;

namespace MovieApp.Context
{
    public class MovieAppContext : DbContext, IDbContext
    {
        public MovieAppContext() : base("name=MovieAppContext")
        {
        }

        public DbSet<Models.Genre> Genres { get; set; }
        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Rating> Ratings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            BuildManyToMany<Models.Genre, Models.Movie>(modelBuilder, s => s.Movies, c => c.Genres, "GenreId", "MovieId", "MovieGenre");
        }

        private void BuildManyToMany<TLeft, TRight>(DbModelBuilder modelBuilder,
                                                    Expression<Func<TLeft, ICollection<TRight>>> rightExpression,
                                                    Expression<Func<TRight, ICollection<TLeft>>> leftExpression,
                                                    string leftKey,
                                                    string rightKey,
                                                    string linkTableName)
            where TLeft : EntityBase
            where TRight : EntityBase
        {
            modelBuilder.Entity<TLeft>()
                .HasMany(rightExpression)
                .WithMany(leftExpression)
                .Map(config =>
                {
                    config.MapLeftKey(leftKey);
                    config.MapRightKey(rightKey);
                    config.ToTable(linkTableName);
                });
        }
    }
}
