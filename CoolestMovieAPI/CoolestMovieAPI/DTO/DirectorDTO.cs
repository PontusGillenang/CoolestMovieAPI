using CoolestMovieAPI.HATEOAS;
using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.DTO
{
    public class DirectorDTO : HateoasLinkBase
    {
        [Required]
        public int DirectorId { get; set; }
        [Required]
        public string DirectorName { get; set; }
        public DateTime DirectorBirthDate { get; set; }
        public string DirectorCountry { get; set; }
        
        [Display(Name = "Directed")]
        public ICollection<MovieDirectorDTO> MovieDirectors { get; set; }
    }
}
