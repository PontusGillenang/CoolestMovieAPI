using CoolestMovieAPI.Models;
using CoolestTrailerAPI.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.DTO
{
    public class MovieDTO
    {        
        [Required]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        public TimeSpan length { get; set; }       
        public Director Director { get; set; }
        public int rating { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public int yearOfRelease { get; set; }
        public ICollection<MovieDirectorDTO> MovieDirectors { get; set; }
        public IList<GenreDTO> genres { get; set; }     
        public ICollection<TrailerDTO> trailers { get; set; }
        public Dictionary<string, ActorDTO> cast { get; set; }

        public MovieDTO()
        {

        }
        public MovieDTO(string role, ActorDTO actor)
        {
           
            cast = new Dictionary<string, ActorDTO>();
            cast.Add(role, actor);

            
        }

    }
}
