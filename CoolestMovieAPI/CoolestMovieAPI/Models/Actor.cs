using System;
using System.Collections.Generic;

namespace CoolestMovieAPI.Models

{
    public class Actor
    {
        public int ActorID { get; set; }
        public string ActorName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorCountry { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
