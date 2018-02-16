using System.ComponentModel.DataAnnotations;
using MovieApp.Interfaces;
using Newtonsoft.Json;

namespace MovieApp.Models
{
    public class Rating : IRating
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
        public int UserId  { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public double Score { get; set; }
    }
}