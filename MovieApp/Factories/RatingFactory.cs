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
            var ratingDbo = db.Ratings.FirstOrDefault(x => x.MovieId == rating.MovieId && x.UserId == rating.UserId);

            if (ratingDbo != null)
            {
                ratingDbo.Score = rating.Score;

                db.Entry(ratingDbo).State = EntityState.Modified;
            }
            else {
                db.Ratings.Add(new Rating { MovieId = rating.MovieId, UserId = rating.UserId, Score = rating.Score });
            }
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
