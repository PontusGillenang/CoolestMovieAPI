using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolestMovieAPI.DTO;

namespace CoolestMovieAPI.Models
{
    public class MovieActorDTO
    {
        public int MovieActorID { get; set; }
        public string Role { get; set; }
        public MovieDTO Movie { get; set; }
        public ActorDTO Actor { get; set; }
    }
}
