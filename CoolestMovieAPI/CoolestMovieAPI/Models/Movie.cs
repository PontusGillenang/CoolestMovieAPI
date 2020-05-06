using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<MovieDirector> movieDirectors { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public List<Trailer> Trailers { get; set; }

    }
}
