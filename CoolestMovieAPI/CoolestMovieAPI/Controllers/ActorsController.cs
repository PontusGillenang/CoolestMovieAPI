using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        public ActorsController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;   
        }
        [HttpGet]
        public Task<IList<Actor>> GetAllActors()
        {
            return _repository.GetAllActors();
        }
        [HttpGet("{id}")]
        public Task<Actor> GetActorById(int id)
        {
            return _repository.GetActorsById(id);
        }
        [HttpGet("name={name}")]
        public Task<IList<Actor>> GetActorsByName(string name)
        {
            return _repository.GetActorsByName(name);
        }
        [HttpGet("country={country}")]
        public Task<IList<Actor>> GetAllActorsByCountry(string country)
        {       
            return _repository.GetAllActorsByCountry(country);
        }
    }
}
