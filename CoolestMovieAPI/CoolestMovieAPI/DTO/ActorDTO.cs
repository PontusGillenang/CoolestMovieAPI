using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CoolestMovieAPI.HATEOAS;

namespace CoolestMovieAPI.DTO
{
    public class ActorDTO : HateoasLinkBase
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ActorName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorCountry { get; set; }
        public string Role { get; set; }
    }
}
