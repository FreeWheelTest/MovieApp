using System;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Interfaces;
using MovieApp.Models;
using MovieApp.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MovieApp.Factories
{
    public class UserFactory : IUserFactory
    {
        private MovieAppContext db = new MovieAppContext();

        public IEnumerable<IUser> GetUsers()
        {
            return db.Users.ToList();
        }

        public IUser GetUser(int id)
        {
            return db.Users.Find(id);
        }

        public bool PutUser(int id, IUser user)
        {

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        public bool PostUser(IUser user)
        {
            db.Users.Add(new User { Email = user.Email });
            db.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return false;
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return true;
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
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
