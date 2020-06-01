namespace CoolestMovieAPI.Models
{
    public class MovieActor
    {
        public int MovieActorID { get; set; }
        public string Role { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
