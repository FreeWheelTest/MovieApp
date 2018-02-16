using System.ComponentModel.DataAnnotations;
using MovieApp.Interfaces;
using System;

namespace MovieApp.Models
{
    public class Movie : IMovie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public TimeSpan RunningTime { get; set; }
        [ScaffoldColumn(false)]
        public double AverageRating { get; set; }
    }
}