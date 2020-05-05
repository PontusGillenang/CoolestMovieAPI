using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly DirectorRepository _repository;

        [HttpGet]
        public Task<Director> GetAll()
        {
            return _repository.GetAllDirector();
        }

        [HttpGet("{id}")]
        public Task<Director> GetById(int id)
        {
            return _repository.GetDirectorById(id);
        }

        [HttpGet("name={name}")]
        public Task<Director> GetByName(string name)
        {
            return _repository.GetDirectorByName(name);
        }

        [HttpGet("country={country}")]
        public Task<Director> GetByCountry(string country)
        {
            return _repository.GetDirectorByCountry(country);
        }
    }
}
