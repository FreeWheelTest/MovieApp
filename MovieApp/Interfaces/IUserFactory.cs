using System;
using System.Collections.Generic;

namespace MovieApp.Interfaces
{
    public interface IUserFactory
    {
        IEnumerable<IUser> GetUsers();
        IUser GetUser(int id);
        bool PutUser(int id, IUser movie);
        bool PostUser(IUser movie);
        bool DeleteUser(int id);
    }
}
