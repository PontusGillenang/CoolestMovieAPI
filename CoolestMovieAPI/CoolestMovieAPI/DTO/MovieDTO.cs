using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.DTO
{
    public class MovieDTO
    {        
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Length { get; set; }       
        public Director Director { get; set; }
        public int Rating { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }     
        public ICollection<Trailer> Trailers { get; set; }      
        public Dictionary<string, Actor> Cast { get; set; }

    }
}
