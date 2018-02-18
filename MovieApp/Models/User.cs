using System.ComponentModel.DataAnnotations;
using MovieApp.Interfaces;

namespace MovieApp.Models
{
    public class User : EntityBase, IUser
    {
        public string Email { get; set; }
    }
}