using CoolestMovieAPI.HATEOAS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoolestMovieAPI.DTO
{
    public class GenreDTO : HateoasLinkBase
    {
        public int GenreID { get; set; }
        public string GenreType { get; set; }
    }
}
