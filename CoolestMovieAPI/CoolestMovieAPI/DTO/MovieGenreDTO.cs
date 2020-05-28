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
    public class MovieGenreDTO
    {
        public int MovieGenreID { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
