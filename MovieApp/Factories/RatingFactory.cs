using System.Collections.Generic;
using System.Linq;
using MovieApp.Interfaces;
using MovieApp.Models;
using MovieApp.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MovieApp.Factories
{
    public class RatingFactory : IRatingFactory
    {
        private MovieAppContext db = new MovieAppContext();

        public IEnumerable<IRating> GetRatings()
        {
            return db.Ratings.ToList();
        }

        public IRating GetRating(int id)
        {
            return db.Ratings.Find(id);
        }

        public double GetRatingAverageByMovie(int id)
        {
            var ratings = db.Ratings.Where(x => x.MovieId == id);
            if (ratings.Count() > 0)
            {
                return ratings.Average(x => x.Score);
            } else
            {
                return 0;
            }
        }

        public bool PutRating(int id, IRating rating)
        {

            db.Entry(rating).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        public bool PostRating(IRating rating)
        {
            db.Ratings.Add(new Rating { MovieId = rating.MovieId, UserId = rating.UserId, Score = rating.Score });
            db.SaveChanges();

            return true;
        }

        public bool DeleteRating(int id)
        {
            var rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return false;
            }

            db.Ratings.Remove(rating);
            db.SaveChanges();

            return true;
        }

        private bool RatingExists(int id)
        {
            return db.Ratings.Count(e => e.Id == id) > 0;
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
