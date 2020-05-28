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
    public class GenreDTO
    {
        public int GenreID { get; set; }
        public string GenreType { get; set; }
    }
}
