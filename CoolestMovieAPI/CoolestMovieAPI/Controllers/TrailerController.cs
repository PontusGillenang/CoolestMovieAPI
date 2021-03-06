﻿using CoolestTrailerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoolestMovieAPI.Models;
using Microsoft.AspNetCore.Http;
using Castle.Core.Internal;
using AutoMapper;
using CoolestTrailerAPI.DTO;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TrailersController : HateoasTrailersControllerBase
    {
        private readonly ITrailerRepository _trailerRepository;
        private readonly IMapper _mapper;

        public TrailersController(ITrailerRepository trailerRepository, IMapper mapper, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
        {
            _trailerRepository = trailerRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllTrailers")]
        public async Task<ActionResult<IList<TrailerDTO>>> GetAll()
        {
            try
            {
                var results = await _trailerRepository.GetAllTrailers();
                var mappedResults = _mapper.Map<IList<TrailerDTO>>(results);
                var hateoasResults = mappedResults.Select(t => HateoasMainLinks(t));

                if (mappedResults.IsNullOrEmpty()) return NotFound();

                return Ok(hateoasResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetTrailerByIdAsync")]
        public async Task<ActionResult<TrailerDTO>> GetById(int id)
        {
            try
            {
                var result = await _trailerRepository.GetTrailerById(id);
                var mappedResult = _mapper.Map<TrailerDTO>(result);

                if (mappedResult == null) return NotFound();

                return Ok(HateoasGetSingleMethodLinks(mappedResult));
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
        [Authorize]
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

        [HttpPut("{trailerId}", Name ="UpdateTrailer")]
        [Authorize]
        public async Task<ActionResult> UpdateTrailer(int trailerId, TrailerDTO trailerDto)
        {
            try
            {
                var oldTrailer = await _trailerRepository.GetTrailerById(trailerId);

                if (oldTrailer == null)
                {
                    return NotFound("$Could not find trailer");
                }

                var newTrailer = _mapper.Map(trailerDto, oldTrailer);
                _trailerRepository.Update(newTrailer);

                if (await _trailerRepository.Save()) return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{trailerId}", Name ="DeleteTrailer")]
        [Authorize]
        public async Task<ActionResult> DeleteTrailer(int trailerId)
        {
            try
            {
                var oldTrailer = await _trailerRepository.GetTrailerById(trailerId);

                if (oldTrailer == null) return NotFound($"Could not find trailer with id {trailerId}");

                _trailerRepository.Delete(oldTrailer);

                if (await _trailerRepository.Save()) return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            
            return BadRequest();
        }
    }
}
