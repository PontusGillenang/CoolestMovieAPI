using CoolestMovieAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public Dictionary<string, ActorDTO> cast { get; set; }

        public MovieDTO()
        {

        }
        public MovieDTO(string role, ActorDTO actor)
        {
            //genres = new List<Genre>();
            cast = new Dictionary<string, ActorDTO>();
            cast.Add(role, actor);

            
        }

    }
}
