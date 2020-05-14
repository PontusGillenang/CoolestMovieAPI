using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
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
        public Task<IList<Director>> GetAll()
        {
            return _directorRepository.GetAllDirectors();
        }

        [HttpGet("{id}")]
        public Task<Director> GetById(int id)
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
