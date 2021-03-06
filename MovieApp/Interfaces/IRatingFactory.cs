﻿using System.Collections.Generic;

namespace MovieApp.Interfaces
{
    public interface IRatingFactory
    {
        IEnumerable<IRating> GetRatings();
        IRating GetRating(int id);
        bool PutRating(int id, IRating movie);
        bool PostRating(IRating movie);
        bool DeleteRating(int id);
    }
}
