using AutoMapper;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    public class ActorsController : HateoasActorControllerBase
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorsController(
            IActorRepository actorRepository,
            IMapper mapper,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllActors")]
        public async Task<ActionResult<IList<ActorDTO>>> GetAllActors()
        {
            try
            {
                var result = await _actorRepository.GetAllActors();
                var mappedResults = _mapper.Map<IList<ActorDTO>>(result).Select(a => HateoasMainLinks(a));

                if (result.Count == 0) return NotFound(result);
                return Ok(mappedResults);
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetActorById")]
        public async Task<ActionResult<ActorDTO>> GetActorById(int id)
        {
            try
            {
                var result = await _actorRepository.GetActorsById(id);

                if (result == null) return NotFound();

                var mappedResults = _mapper.Map<ActorDTO>(result);

                return Ok(HateoasMainLinks(mappedResults));
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchactor", Name = "GetActorByName")]
        public async Task<ActionResult<IList<ActorDTO>>> GetActorsByName([FromQuery]string name)
        {
            try
            {
                var result = await _actorRepository.GetActorsByName(name);
                var mappedResults = _mapper.Map<IList<ActorDTO>>(result).Select(a => HateoasMainLinks(a));

                if (result.Count == 0) return NotFound();
                return Ok(mappedResults);

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchcountry", Name = "GetActorsByCountry")]
        public async Task<ActionResult<IList<ActorDTO>>> GetByCountry([FromQuery]string country)
        {
            try
            {
                var result = await _actorRepository.GetActorsByCountry(country);
                var mappedResults = _mapper.Map<IList<ActorDTO>>(result).Select(a => HateoasMainLinks(a));

                if (result.Count == 0) return NotFound(result);
                return Ok(mappedResults);

            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchmovie", Name = "GetActorsByMovie")]
        public async Task<ActionResult<IList<ActorDTO>>> GetByMovie([FromQuery]string movie)
        {
            try
            {
                var result = await _actorRepository.GetActorsByMovie(movie);
                var mappedResults = _mapper.Map<IList<ActorDTO>>(result).Select(a => HateoasMainLinks(a));

                if (result.Count == 0) return NotFound(result);
                return Ok(mappedResults);

            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ActorDTO>> PostActor(ActorDTO actorDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Actor>(actorDto);

                _actorRepository.Add(mappedEntity);
                if (await _actorRepository.Save())
                {
                    return Created($"/api/v1.0/actors/{mappedEntity.ActorID}", _mapper.Map<ActorDTO>(mappedEntity));
                }
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{actorId}")]
        public async Task<ActionResult> PutActor(int actorId, ActorDTO actorDto)
        {
            try
            {
                var oldActor = await _actorRepository.GetActorsById(actorId);
                if (oldActor == null)
                {
                    return NotFound("$Could not find actor");
                }

                var newActor = _mapper.Map(actorDto, oldActor);
                _actorRepository.Update(newActor);
                if (await _actorRepository.Save())
                {
                    return NoContent();
                }
            }

            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{actorId}")]
        public async Task<ActionResult> DeleteActor(int actorId)
        {
            try
            {
                var oldActor = await _actorRepository.GetActorsById(actorId);

                if (oldActor == null)
                {
                    return NotFound($"Could not find actor with id {actorId}");
                }

                _actorRepository.Delete(oldActor);

                if (await _actorRepository.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }
    }
}
