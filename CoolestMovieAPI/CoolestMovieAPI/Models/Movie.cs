using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public TimeSpan MovieLength { get; set; }
        public double MovieRating { get; set; }
        public string MovieDescription { get; set; }      
        public int MovieReleaseYear { get; set; }        
        public ICollection<MovieDirector> MovieDirectors { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public IList<MovieGenre> MovieGenre { get; set; }
        public IList<Trailer> Trailers { get; set; }
    }
}
