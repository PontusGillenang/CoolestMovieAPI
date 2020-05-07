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
        private readonly IDirectorRepository _repository;
        
        public DirectorsController(MovieContext context)
        {
            _repository = new DirectorRepository(context);
        }

        [HttpGet]
        public Task<IList<Director>> GetAll()
        {
            return _repository.GetAllDirectors();
        }

        [HttpGet("{id}")]
        public Task<Director> GetById(int id)
        {
            return _repository.GetDirectorById(id);
        }

        [HttpGet("name={name}")]
        public Task<IList<Director>> GetByName(string name)
        {
            return _repository.GetDirectorsByName(name);
        }

        [HttpGet("country={country}")]
        public Task<IList<Director>> GetByCountry(string country)
        {
            return _repository.GetDirectorsByCountry(country);
        }
    }
}
