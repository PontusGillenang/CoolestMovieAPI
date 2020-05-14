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
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public string country { get; set; }
        public string role { get; set; }
        public Movie movie { get; set; }
        //public Dictionary<string,Movie> roll { get; set; }
    }

}
