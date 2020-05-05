using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class MovieActor
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }


        public int ActorID { get; set; }
        public Actor Actor { get; set; }
    }
}
