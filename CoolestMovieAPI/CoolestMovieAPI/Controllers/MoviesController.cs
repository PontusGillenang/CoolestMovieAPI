using AutoMapper;
using CoolestMovieAPI.DTO;
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
       

        [HttpGet]
        public async Task<ActionResult<IList<Movie>>> GetAll()
        {
            try
            {
                var results = await _movieRepository.GetAllMovies();

                if (results.Count == 0)
                {
                    return NotFound();
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

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            try
            {
                var result = await _movieRepository.GetMovieById(id);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchtitle")]
        public async Task<ActionResult<IList<Movie>>> GetByTitle([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetMovieByTitle(name);

                if (results.Count == 0)
                {
                    return NotFound();
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

        [HttpGet("searchactor")]
        public async Task<ActionResult<IList<MovieDirector>>> GetByActor([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetByActor(name);

                if (results.Count == 0)
                {
                    return NotFound();
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

        [HttpGet("searchdirector")]
        public async Task<ActionResult<IList<MovieDirector>>> GetByDirector([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetByDirector(name);

                if (results.Count == 0)
                {
                    return NotFound();
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
        
        [HttpGet("searchyear")]
        public async Task<ActionResult<IList<Movie>>> GetByYear([FromQuery]int year)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYear(year);
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

        [HttpGet("searchyeargreaterthan")]
        public async Task<ActionResult<IList<Movie>>> GetByYearGreaterThan([FromQuery]int year)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYearGreaterThan(year);
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

        [HttpGet("searchyearlessthan")]
        public async Task<ActionResult<IList<Movie>>> GetByYearLessThan([FromQuery]int year)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYearLessThan(year);
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

        [HttpGet("searchyearspan")]
        public async Task<ActionResult<IList<Movie>>> GetByYearSpan([FromQuery]int year, int maxYear)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYearSpan(year, maxYear);
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

        [HttpGet("searchrating")]
        public async Task<ActionResult<IList<Movie>>> GetByRating([FromQuery]double rating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRating(rating);
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

        [HttpGet("searchratinggreaterthan")]
        public async Task<ActionResult<IList<Movie>>> GetByRatingGreaterThan([FromQuery]double rating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRatingGreaterThan(rating);
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

        [HttpGet("searchratinglessthan")]
        public async Task<ActionResult<IList<Movie>>> GetByRatingLessThan([FromQuery]double rating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRatingLessThan(rating);
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

        [HttpGet("searchratingspan")]
        public async Task<ActionResult<IList<Movie>>> GetByRatingSpan([FromQuery]double rating, double maxRating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRatingSpan(rating, maxRating);
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

        [HttpGet("searchlength")]
        public async Task<ActionResult<IList<Movie>>> GetByLength([FromQuery]TimeSpan length)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLength(length);
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

        [HttpGet("searchlengthgreaterthan")]
        public async Task<ActionResult<IList<Movie>>> GetByLengthGreaterThan([FromQuery]TimeSpan length)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLengthGreaterThan(length);
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

        [HttpGet("searchlengthlessthan")]
        public async Task<ActionResult<IList<Movie>>> GetByLengthLessThan([FromQuery]TimeSpan length)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLengthLessThan(length);
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

        [HttpGet("searchlengthspan")]
        public async Task<ActionResult<IList<Movie>>> GetByLengthSpan([FromQuery]TimeSpan length, [FromQuery]TimeSpan maxLength)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLengthSpan(length, maxLength);
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
}
