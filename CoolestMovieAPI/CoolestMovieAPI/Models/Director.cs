using System;
using System.Collections.Generic;

namespace CoolestMovieAPI.Models
{
    public class Director
    {
        public int DirectorID { get; set; }
        public string DirectorName { get; set; }
        public DateTime DirectorBirthDate { get; set; }
        public string DirectorCountry { get; set; }
        public ICollection<MovieDirector> MovieDirectors { get; set; }
    }
}
