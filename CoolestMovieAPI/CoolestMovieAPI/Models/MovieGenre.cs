using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class MovieGenre
    {
        public int MovieGenreID { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
