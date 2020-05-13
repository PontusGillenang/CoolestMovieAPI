using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
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
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            try
            {
                var results = await _movieRepository.GetMovieById(id);
                return Ok(results);

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }

        }

        [HttpGet("title={title}")]
        public async Task<ActionResult<IList<Movie>>> GetByTitle(string title)
        {
            try
            {
                var results = await _movieRepository.GetMovieByTitle(title);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }

        }

        [HttpGet]
        public async Task<ActionResult<IList<Movie>>> GetByYear([FromQuery]int year = 0)
        {
            if (year == 0)
            {
                try
                {
                    var results = await _movieRepository.GetAllMovies();
                    return Ok(results);
                }
                catch (Exception e)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
                }

            }
            else
            {
                try
                {
                    var results = await _movieRepository.GetMovieByYear(year);
                    if (results.Count == 0)
                    {
                        return NotFound(results);

                    }
                    else
                    {
                        return Ok(results);
                    }
                }
                catch (Exception e)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
                }

            }

        }

        [HttpGet("rating={rating}")]
        public async Task<ActionResult<IList<Movie>>> GetByRating(double rating)
        {
            try
            {
                var results = await _movieRepository.GetMovieByRating(rating);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("length={length}")]
        public async Task<ActionResult<IList<Movie>>> GetByLength(TimeSpan movieLength)
        {
            try
            {
                var results = await _movieRepository.GetByLength(movieLength);
                if (results == null)
                {
                    return NotFound(results);
                    
                }
                else
                {
                    return Ok(results);
                }
                
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }

        }

        [HttpGet("director={directorName}")]
        public async Task<ActionResult<IList<MovieDirector>>> GetByDirector(string directorName)
        {
            try
            {
                var results = await _movieRepository.GetByDirector(directorName);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("genre={genre}")]
        public Task<IList<Movie>> GetByLength(string genre)
        {
            return _repository.GetMovieByGenre(genre);
        }
    }
}
   


