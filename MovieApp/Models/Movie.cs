using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MovieApp.Interfaces;
using System;
using Newtonsoft.Json;

namespace MovieApp.Models
{
    public class Movie : EntityBase, IMovie
    {
        [JsonProperty(Order = 2)]
        public virtual string Title { get; set; }
        [JsonProperty(Order = 3)]
        public virtual int YearOfRelease { get; set; }
        [JsonProperty(Order = 4)]
        public virtual TimeSpan RunningTime { get; set; }
        [NotMapped]
        [JsonProperty(Order = 5)]
        public virtual string AverageRating { get; set; }
        [JsonProperty(Order = 6)]
        public virtual ICollection<Genre> Genres { get; set; }
    }
}