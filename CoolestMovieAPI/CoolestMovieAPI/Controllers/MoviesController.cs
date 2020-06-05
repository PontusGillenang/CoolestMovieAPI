using AutoMapper;
using Castle.Core.Internal;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using CoolestMovieAPI.Pagination;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class MoviesController : HateoasMoviesControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
      

        public MoviesController(IMovieRepository movieRepository, IMapper mapper, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
       

        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<IList<MovieDTO>>> GetAll([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                var results = await _movieRepository.GetAllMovies(paginationParameters);
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                var totalMovieCount = await _movieRepository.GetMovieCount();

                var links = GetPaginationLinks(paginationParameters, totalMovieCount);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new
                    {
                        links = links,
                        results = hateoasResults
                    });
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetIdAsync")]
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
                    return Ok(HateoasGetSingleMethodLinks(mappedResult));
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }
        
        //search contains instead of starts with x letters. More userfriendly
        [HttpGet("searchtitle")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByTitle([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetMovieByTitle(name);
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
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
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("genre")]
        public async Task<ActionResult<IList<MovieDTO>>> GetByGenre([FromQuery]string name)
        {
            try
            {
                var results = await _movieRepository.GetMoviesByGenre(name);
                IEnumerable<MovieDTO> mappedResults = _mapper.Map<IList<MovieDTO>>(results);
                IEnumerable<MovieDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure, could not retrieve movies by genre. {e.Message}");
            }
        }
        
        [HttpPost(Name = "CreateMovie")]
        [Authorize]
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

        [HttpPut("{movieId}", Name = "UpdateMovie")]
        [Authorize]
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

        [HttpDelete("{movieId}", Name = "DeleteMovie")]
        [Authorize]
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
