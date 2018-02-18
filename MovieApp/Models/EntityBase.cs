using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MovieApp.Models
{
    public abstract class EntityBase
    {
        [Key]
        [JsonProperty(Order = 1)]
        public int Id { get; set; }
    }
}