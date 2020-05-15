using AutoMapper;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public class MappedProfile : Profile
    {
        public MappedProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ReverseMap();
            
            CreateMap<Actor, ActorDTO>()
                .ReverseMap();
            
        }
       

    }
}
