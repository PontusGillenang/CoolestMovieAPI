using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.DTO
{
    public class MovieDTO
    {        
        public int id { get; set; }
        public string title { get; set; }
        public TimeSpan length { get; set; }       
        public Director Director { get; set; }
        public int rating { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public int yearOfRelease { get; set; }
        public IList<Genre> genres { get; set; }     
        public ICollection<Trailer> trailers { get; set; }      
        public Dictionary<string, Actor> cast { get; set; }

        public MovieDTO()
        {
            genres = new List<Genre>();
        }

    }
}
