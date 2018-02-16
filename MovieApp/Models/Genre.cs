using System.ComponentModel.DataAnnotations;
using MovieApp.Interfaces;

namespace MovieApp.Models
{
    public class Genre : IGenre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}