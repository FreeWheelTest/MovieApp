using System.Collections.Generic;
using MovieApp.Interfaces;
using Newtonsoft.Json;

namespace MovieApp.Models
{
    public class Genre : EntityBase, IGenre
    {
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}