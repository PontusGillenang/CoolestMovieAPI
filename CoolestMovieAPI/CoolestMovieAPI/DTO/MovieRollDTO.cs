using CoolestMovieAPI.Models;
using CoolestTrailerAPI.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.DTO
{
    public class MovieRollDTO : MovieDTO
    {
        public string Role { get; set; }
    }
}
