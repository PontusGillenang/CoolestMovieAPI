using CoolestTrailerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoolestMovieAPI.Models;
using Microsoft.AspNetCore.Http;
using Castle.Core.Internal;
using AutoMapper;
using CoolestTrailerAPI.DTO;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TrailersController : ControllerBase
    {
        private readonly ITrailerRepository _trailerRepository;
        private readonly IMapper _mapper;

        public TrailersController(ITrailerRepository trailerRepository, IMapper mapper)
        {
            _trailerRepository = trailerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<TrailerDTO>>> GetAll()
        {
            try
            {
                var results = await _trailerRepository.GetAllTrailers();
                var mappedResults = _mapper.Map<IList<TrailerDTO>>(results);

                if (mappedResults.IsNullOrEmpty()) return NotFound();

                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrailerDTO>> GetById(int id)
        {
            try
            {
                var result = await _trailerRepository.GetTrailerById(id);
                var mappedResult = _mapper.Map<TrailerDTO>(result);

                if (mappedResult == null) return NotFound();

                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("searchtitle")]
        public async Task<ActionResult<IList<TrailerDTO>>> GetTrailerByTitle([FromQuery] string name)
        {
            try
            {
                var results = await _trailerRepository.GetTrailerByTitle(name);
                var mappedResults = _mapper.Map<IList<TrailerDTO>>(results);

                if (mappedResults.IsNullOrEmpty()) return NotFound();

                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<TrailerDTO>> PostActor(TrailerDTO trailerDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Trailer>(trailerDto);

                _trailerRepository.Add(mappedEntity);
                if (await _trailerRepository.Save())
                {
                    return Created($"/api/v1.0/actors/{mappedEntity.TrailerID}", _mapper.Map<TrailerDTO>(mappedEntity));
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
