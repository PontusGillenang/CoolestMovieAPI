using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreType { get; set; }
        public ICollection<MovieGenre> MovieGenre { get; set; }

    }
}
