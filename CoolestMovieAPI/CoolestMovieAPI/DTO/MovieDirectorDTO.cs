using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.DTO
{
    public class MovieDirectorDTO
    {
        public int MovieDirectorID { get; set; }
        public MovieDTO Movie { get; set; }
        public DirectorDTO Director { get; set; }
    }
}
