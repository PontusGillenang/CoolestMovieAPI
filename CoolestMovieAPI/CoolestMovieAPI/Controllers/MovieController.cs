using CoolestMovieAPI.Models;
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
    public class MovieController : ControllerBase
    { 
        private MovieRepository _repository;
        
        [HttpGet]
        public Task<Movie> GetAll()
        {
            return _repository.GetAllMovies();
        }

        [HttpGet("{id}")]
        public Task<Movie> Get(string id)
        {
            return _repository.GetMovieById(id);
        }
    }
}
