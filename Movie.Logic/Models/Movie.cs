using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieApp.Logic.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Logic.Models
{
    public class Movie : IMovie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}