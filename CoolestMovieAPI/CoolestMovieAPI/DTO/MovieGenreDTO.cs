using CoolestMovieAPI.Models;

namespace CoolestMovieAPI.DTO
{
    public class MovieGenreDTO
    {
        public int MovieGenreID { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
