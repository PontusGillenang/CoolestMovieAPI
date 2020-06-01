namespace CoolestMovieAPI.Models
{
    public class MovieDirector
    {
        public int MovieDirectorID { get; set; }
        public Movie Movie { get; set; }
        public Director Director { get; set; }
    }
}
