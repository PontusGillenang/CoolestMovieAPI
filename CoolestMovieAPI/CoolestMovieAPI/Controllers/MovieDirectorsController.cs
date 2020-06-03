using AutoMapper;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class MovieDirectorsController : ControllerBase
    {
        private readonly IMovieDirectorsRepository _movieDirectorsRepository;
        private readonly IMapper _mapper;
        public MovieDirectorsController(IMovieDirectorsRepository movieDirectorsRepository, IMapper mapper)
        {
            _movieDirectorsRepository = movieDirectorsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<MovieDirectorDTO>>> GetAllMovieDirectors()
        {
            try
            {
                var result = await _movieDirectorsRepository.GetAllMovieDirectors();
                var mappedResults = _mapper.Map<IList<MovieDirectorDTO>>(result);

                if (result.Count == 0)
                {
                    return NotFound(result);
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
        public async Task<ActionResult<MovieDirectorDTO>> PostMovieDirector(int movieId, int directorId)
        {
            try
            {
                var movie = await _movieDirectorsRepository.GetMovieById(movieId);
                var director = await _movieDirectorsRepository.GetDirectorById(directorId);
                
                if (movie == null)
                {
                    return BadRequest($"Unable to find movie with Id: {movieId}");
                }
                else if (director == null)
                    return BadRequest($"Unable to find director with Id: {directorId}");


                var movieDirector = new MovieDirector { Movie = movie, Director = director };

                _movieDirectorsRepository.Add(movieDirector);

                if(await _movieDirectorsRepository.Save())
                {
                    return Created($"/api/v1.0/MovieDirectors/{movieDirector.MovieDirectorID}", _mapper.Map<MovieDirectorDTO>(movieDirector));
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
