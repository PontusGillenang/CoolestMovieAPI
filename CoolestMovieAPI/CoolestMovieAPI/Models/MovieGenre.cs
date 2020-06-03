namespace CoolestMovieAPI.Models
{
    public class MovieGenre
    {
        public int MovieGenreID { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
