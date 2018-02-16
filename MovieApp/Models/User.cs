using System.ComponentModel.DataAnnotations;
using MovieApp.Interfaces;

namespace MovieApp.Models
{
    public class User : IUser
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
    }
}