using AutoMapper;
using Castle.Core.Internal;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorsController(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<DirectorDTO>>> GetAll()
        {
            try
            {
                var results = await _directorRepository.GetAllDirectors();
                var mappedResults = _mapper.Map<IList<DirectorDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDTO>> GetById(int id)
        {
            try
            {
                var result = await _directorRepository.GetDirectorById(id);
                var mappedResult = _mapper.Map<IList<DirectorDTO>>(result);

                if (mappedResult == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResult);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }

        [HttpGet("searchname")]
        public async Task<ActionResult<IList<DirectorDTO>>> GetByName([FromQuery] string name)
        {
            try
            {
                var results = await _directorRepository.GetDirectorsByName(name);
                var mappedResults = _mapper.Map<IList<DirectorDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }

        [HttpGet("searchcountry")]
        public async Task<ActionResult<IList<DirectorDTO>>> GetByCountry([FromQuery] string country)
        {
            try
            {
                var results = await _directorRepository.GetDirectorsByCountry(country);
                var mappedResults = _mapper.Map<IList<DirectorDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }
    }
}
