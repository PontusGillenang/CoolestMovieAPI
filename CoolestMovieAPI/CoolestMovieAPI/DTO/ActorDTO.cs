using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoolestMovieAPI.DTO
{
    public class ActorDTO
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorCountry { get; set; }
        public string Role { get; set; }
        public Movie Movie { get; set; }
        public Dictionary<string, Movie> Roll { get; set; }
    }
}
