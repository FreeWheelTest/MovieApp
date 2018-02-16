using System;
using System.Collections.Generic;
using MovieApp.Models;

namespace MovieApp.Interfaces
{
    public interface IMovie
    {
        int Id { get; set; }
        string Title { get; set; }
        int YearOfRelease { get; set; }
        TimeSpan RunningTime { get; set; }
        double AverageRating { get; set; }
    }
}
