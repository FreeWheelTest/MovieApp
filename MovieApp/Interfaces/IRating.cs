using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Interfaces
{
    public interface IRating
    {
        int MovieId { get; set; }
        int UserId { get; set; }
        double Score { get; set; }
    }
}
