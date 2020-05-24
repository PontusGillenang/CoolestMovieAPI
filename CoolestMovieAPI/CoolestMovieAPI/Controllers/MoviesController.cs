using AutoMapper;
using Castle.Core.Internal;
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
        private readonly IMapper _mapper;
      

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
       

        [HttpGet]
        public async Task<ActionResult<IList<MovieDTO>>> GetAll()
        {
            try
            {
                var results = await _movieRepository.GetAllMovies();
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
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
                var mappedResult = _mapper.Map<MovieDTO>(result);

                if (mappedResult == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResult);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchtitle")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByTitle([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetMovieByTitle(name);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchactor")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByActor([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetByActor(name);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchdirector")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByDirector([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetByDirector(name);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }
        
        [HttpGet("searchyear")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByYear([FromQuery]int year)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYear(year);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchyeargreaterthan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByYearGreaterThan([FromQuery]int year)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYearGreaterThan(year);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchyearlessthan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByYearLessThan([FromQuery]int year)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYearLessThan(year);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchyearspan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByYearSpan([FromQuery]int year, int maxYear)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByYearSpan(year, maxYear);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchrating")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByRating([FromQuery]double rating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRating(rating);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchratinggreaterthan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByRatingGreaterThan([FromQuery]double rating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRatingGreaterThan(rating);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchratinglessthan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByRatingLessThan([FromQuery]double rating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRatingLessThan(rating);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchratingspan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByRatingSpan([FromQuery]double rating, double maxRating)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByRatingSpan(rating, maxRating);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchlength")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByLength([FromQuery]TimeSpan length)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLength(length);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchlengthgreaterthan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByLengthGreaterThan([FromQuery]TimeSpan length)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLengthGreaterThan(length);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchlengthlessthan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByLengthLessThan([FromQuery]TimeSpan length)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLengthLessThan(length);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchlengthspan")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByLengthSpan([FromQuery]TimeSpan length, [FromQuery]TimeSpan maxLength)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByLengthSpan(length, maxLength);
                var mappedResults = _mapper.Map<IList<MovieDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<MovieDTO>> PostMovie(MovieDTO movieDTO)
        {
            try
            {
                var mappedEntity = _mapper.Map<Movie>(movieDTO);

                _movieRepository.Add(mappedEntity);
                if(await _movieRepository.Save())
                {
                    return Created($"/api/v1.0/movies/{mappedEntity.MovieID}", _mapper.Map<MovieDTO>(mappedEntity));
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{movieId}")]
        public async Task<ActionResult> PutMovie(int movieId, MovieDTO movieDTO)
        {
            try
            {
                var oldMovie = await _movieRepository.GetMovieById(movieId);
                if(oldMovie == null)
                {
                    return NotFound($"Could not find event with id {movieId}");
                }   

                var newMovie = _mapper.Map(movieDTO, oldMovie);
                _movieRepository.Update(newMovie);

                if(await _movieRepository.Save())
                {
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{movieId}")]
        public async Task<ActionResult> DeleteMovie(int movieId)
        {
            try
            {
                var oldMovie = await _movieRepository.GetMovieById(movieId);

                if(oldMovie == null)
                {
                    return NotFound($"Could not find event with id {movieId}");
                }  

                _movieRepository.Delete(oldMovie);

                if(await _movieRepository.Save())
                {
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }
    }
}
