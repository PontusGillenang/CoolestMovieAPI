using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IList<Actor>>> GetAllActors()
        {
            try
            {
                var results = await _actorRepository.GetAllActors();

                if (results.Count == 0)
                {
                    return NotFound(results);
                }
                else
                {
                    return Ok(results);
                }
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActorById(int id)
        {
            try
            {
                var result = await _actorRepository.GetActorsById(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<IList<Actor>>> GetActorsByName(string name)
        {
            try
            {
                var results = await _actorRepository.GetActorsByName(name);
                if (results.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(results);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("country={country}")]
        public async Task<ActionResult<IList<Actor>>> GetActorsByCountry(string country)
        {
            try
            {
                var result = await _actorRepository.GetActorsByCountry(country);
                return Ok(result);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }


            //[HttpGet("country={country}")]
            //public async Task<ActionResult<IList<Actor>>> GetAllActorsByCountry(string country)
            //{
            //    try
            //    {

            //        var results = await _actorRepository.GetAllActors(country);
            //        return Ok(results);
            //    }
            //    catch (Exception e)
            //    {

            //        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            //    }
            //}
        }
    }
}
