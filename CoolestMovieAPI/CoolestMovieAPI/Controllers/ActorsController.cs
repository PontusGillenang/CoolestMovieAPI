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
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        public ActorsController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ActorDTO>>> GetAllActors()
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
        public async Task<ActionResult<ActorDTO>> GetActorById(int id)
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


        [HttpGet("searchname")]
        public async Task<ActionResult<IList<ActorDTO>>> GetActorsByName([FromQuery]string name)
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

        [HttpGet("searchcountry")]
        public async Task<ActionResult<IList<ActorDTO>>> GetByCountry([FromQuery]string country)
        {
            try
            {
                var result = await _actorRepository.GetActorsByCountry(country);
                if (result.Count == 0)
                {
                    return NotFound(result);
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
    }
}
