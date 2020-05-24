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

        [HttpPut]
        public async Task<ActionResult<MovieDirectorDTO>> PostMovieDirector(MovieDirectorDTO movieDirectorDTO)
        {
            try
            {
                var mappedEntity = _mapper.Map<MovieDirector>(movieDirectorDTO);

                _movieDirectorsRepository.Add(mappedEntity);

                if(await _movieDirectorsRepository.Save())
                {
                    return Created($"/api/v1.0/MovieDirectors/{mappedEntity.MovieDirectorID}", _mapper.Map<MovieDirectorDTO>(mappedEntity));
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
