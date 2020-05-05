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
        public TimeSpan Length { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
