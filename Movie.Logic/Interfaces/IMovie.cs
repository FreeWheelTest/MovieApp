using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Logic.Interfaces
{
    public interface IMovie
    {
        int Id { get; set; }
        string Title { get; set; }
        int Year { get; set; }
    }
}
