using AutoMapper;
using Castle.Core.Internal;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository movieDirectorsRepository, IMapper mapper)
        {
            _genreRepository = movieDirectorsRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllGenre")]
        public async Task<ActionResult<IList<GenreDTO>>> GetAll()
        {
            try
            {
                var results = await _genreRepository.GetAllGenre();
                var mappedResults = _mapper.Map<IList<GenreDTO>>(results);

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

        [HttpGet("{id}", Name = "GetIdAsync")]
        public async Task<ActionResult<GenreDTO>> GetById(int id)
        {
            try
            {
                var result = await _genreRepository.GetGenreById(id);
                var mappedResult = _mapper.Map<GenreDTO>(result);

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

        [HttpGet("{id}", Name = "GetGenreByName")]
        public async Task<ActionResult<GenreDTO>> GetByName([FromQuery] string name)
        {
            try
            {
                var result = await _genreRepository.GetGenreByName(name);
                var mappedResult = _mapper.Map<GenreDTO>(result);

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

    }
}
