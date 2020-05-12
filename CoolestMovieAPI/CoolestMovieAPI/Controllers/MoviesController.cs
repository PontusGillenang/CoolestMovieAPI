using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            var title = _movieRepository.GetMovieById(id).Result.MovieTitle.ToString();

            return title;
        }

        [HttpGet("title={title}")]
        public Task<IList<Movie>> GetByTitle(string title)
        {
            return _movieRepository.GetMovieByTitle(title);
        }

        [HttpGet]
        public Task<IList<Movie>> GetByYear([FromQuery]int year = 0)
        {
            if (year == 0)
            {
                return _movieRepository.GetAllMovies();

            }
            else
            {
                return _movieRepository.GetMovieByYear(year);
            }

        }

        [HttpGet("rating={rating}")]
        public Task<IList<Movie>> GetByRating(int rating)
        {
            return _movieRepository.GetMovieByRating(rating);
        }

        //[HttpGet("genre={genre}")]
        //public Task<IList<Movie>> GetByGenre(string genre)
        //{
        //    return _movieRepository.GetMovieByGenre(genre);
        //}

        [HttpGet("length={length}")]
        public Task<IList<Movie>> GetByLength(TimeSpan time)
        {
            return _movieRepository.GetByLength(time);
        }

        [HttpGet("cast={actorFirstName}+{actorLastName}")]
        public Task<IList<Movie>> GetMoviesByActor(string firstName, string lastName)
        {
            return _movieRepository.GetMoviesByActor(firstName, lastName);
        }
    }
}
