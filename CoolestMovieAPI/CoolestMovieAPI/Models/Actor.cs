using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models

{
    public class Actor
    {
        public int ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorCountry { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
