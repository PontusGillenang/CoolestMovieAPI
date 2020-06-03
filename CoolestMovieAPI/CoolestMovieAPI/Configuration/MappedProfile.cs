using AutoMapper;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestTrailerAPI.DTO;

namespace CoolestMovieAPI.Configuration
{
    public class MappedProfile : Profile
    {
        public MappedProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ReverseMap();

            CreateMap<Director, DirectorDTO>()
                .ReverseMap();

            CreateMap<MovieDirector, MovieDirectorDTO>()
                .ReverseMap();

            CreateMap<Actor, ActorDTO>()
                .ReverseMap();

            CreateMap<Trailer, TrailerDTO>()
                .ReverseMap();

            CreateMap<Genre, GenreDTO>()
                .ReverseMap();
        }
    }
}
