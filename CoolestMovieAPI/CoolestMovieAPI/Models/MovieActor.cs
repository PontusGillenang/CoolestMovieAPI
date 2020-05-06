using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class MovieActor
    {
        public int MovieActorID { get; set; }
        public string Roll { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
