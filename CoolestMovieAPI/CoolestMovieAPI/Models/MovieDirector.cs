using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class MovieDirector
    {
        public int MovieID { get; set; }
        public Movie Movie { get; set; }


        public int DirectorID { get; set; }
        public Director Director { get; set; }
    }
}
