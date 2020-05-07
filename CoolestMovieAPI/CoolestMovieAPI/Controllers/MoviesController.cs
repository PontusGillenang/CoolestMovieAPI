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
        private MovieRepository _repository { get; set; }
        
        public MoviesController(MovieContext context, IConfiguration configuration)
        {
            _repository = new MovieRepository(context, configuration);

        }
        
        [HttpGet]
        public Task<IList<Movie>> GetAll()
        {
            return _repository.GetAllMovies();
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            var title = _repository.GetMovieById(id).Result.MovieTitle.ToString();

            return title;
        }

        [HttpGet("title={title}")]
        public Task<IList<Movie>> GetByTitle(string title)
        {
            return _repository.GetMovieByTitle(title);
        }

        [HttpGet("year={year}")]
        public Task<IList<Movie>> GetByYear(int year)
        {
            return _repository.GetMovieByYear(year);
        }

        [HttpGet("rating={rating}")]
        public Task<IList<Movie>> GetByRating(int rating)
        {
            return _repository.GetMovieByRating(rating);
        }

        //[HttpGet("genre={genre}")]
        //public Task<IList<Movie>> GetByGenre(string genre)
        //{
        //    return _repository.GetMovieByGenre(genre);
        //}

        [HttpGet("length={length}")]
        public Task<IList<Movie>> GetByLength(TimeSpan time)
        {
            return _repository.GetByLength(time);
        }

        [HttpGet("cast={actorFirstName}+{actorLastName}")]
        public Task<IList<Movie>> GetMoviesByActor(string firstName, string lastName)
        {
            return _repository.GetMoviesByActor(firstName, lastName);
        }
    }
}
