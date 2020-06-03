using CoolestMovieAPI.HATEOAS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
