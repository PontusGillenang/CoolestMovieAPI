using CoolestMovieAPI.Models;
using CoolestTrailerAPI.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoolestMovieAPI.HATEOAS;

namespace CoolestMovieAPI.DTO
{
    public class MovieDTO : HateoasLinkBase
    {        
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string MovieTitle { get; set; }
        public TimeSpan MovieLength { get; set; }
        public double MovieRating { get; set; }
        public string MovieDescription { get; set; }
        public int MovieReleaseYear { get; set; }
        public ICollection<MovieDirectorDTO> MovieDirectors { get; set; }
    }
}
