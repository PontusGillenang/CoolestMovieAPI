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

        public DirectorsController(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Director>>> GetAll()
        {
            try
            {
                var result = await _directorRepository.GetAllDirectors();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Could not find object: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public  Task<Director> GetById(int id)
        {
                return _directorRepository.GetDirectorById(id);
        }

        [HttpGet("name={name}")]
        public Task<IList<Director>> GetByName(string name)
        {
            return _directorRepository.GetDirectorsByName(name);
        }

        [HttpGet("country={country}")]
        public Task<IList<Director>> GetByCountry(string country)
        {
            return _directorRepository.GetDirectorsByCountry(country);
        }
    }
}
