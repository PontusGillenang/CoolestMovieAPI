using System.Collections.Generic;

namespace CoolestMovieAPI.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreType { get; set; }
        public ICollection<MovieGenre> MovieGenre { get; set; }

    }
}
