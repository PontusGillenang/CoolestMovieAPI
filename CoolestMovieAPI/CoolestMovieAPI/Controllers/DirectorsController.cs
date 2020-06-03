using AutoMapper;
using Castle.Core.Internal;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class DirectorsController : HateoasDirectorsControllerBase
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorsController(IDirectorRepository directorRepository, IMapper mapper, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllDirectors")]
        public async Task<ActionResult<IList<DirectorDTO>>> GetAll()
        {
            try
            {
                var results = await _directorRepository.GetAllDirectors();
                IEnumerable<DirectorDTO> mappedResults = _mapper.Map<IList<DirectorDTO>>(results);
                IEnumerable<DirectorDTO> hateoasResults = mappedResults.Select(m => HateoasMainLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetDirectorIdAsync")]
        public async Task<ActionResult<DirectorDTO>> GetById(int id)
        {
            try
            {
                var result = await _directorRepository.GetDirectorById(id);
                var mappedResult = _mapper.Map<DirectorDTO>(result);

                if (mappedResult == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(HateoasMainLinks(mappedResult));
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }

        [HttpGet("searchname", Name = "GetDirectorByName")]
        public async Task<ActionResult<IList<DirectorDTO>>> GetByName([FromQuery] string name)
        {
            try
            {
                var results = await _directorRepository.GetDirectorsByName(name);

                IEnumerable<DirectorDTO> mappedResults = _mapper.Map<IList<DirectorDTO>>(results);
                IEnumerable<DirectorDTO> hateoasResults = mappedResults.Select(m => HateoasMainLinks(m));
                
                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }

        [HttpGet("searchcountry", Name = "GetDirectorByCountry")]
        public async Task<ActionResult<IList<DirectorDTO>>> GetByCountry([FromQuery] string country)
        {
            try
            {
                var results = await _directorRepository.GetDirectorsByCountry(country);

                IEnumerable<DirectorDTO> mappedResults = _mapper.Map<IList<DirectorDTO>>(results);
                IEnumerable<DirectorDTO> hateoasResults = mappedResults.Select(m => HateoasMainLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {exception.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DirectorDTO>> PostDirector(DirectorDTO directorDTO)
        {
            try
            {
                var mappedEntity = _mapper.Map<Director>(directorDTO);

                _directorRepository.Add(mappedEntity);
                if (await _directorRepository.Save())
                {
                    return Created($"/api/v1.0/directors/{mappedEntity.DirectorID}", _mapper.Map<DirectorDTO>(mappedEntity));
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutDirector(int id, DirectorDTO directorDTO)
        {
            try
            {
                var existingDirector = await _directorRepository.GetDirectorById(id);
                if (existingDirector == null)
                {
                    return NotFound($"Could not find a director with id {id}");
                }

                var updatedDirector = _mapper.Map(directorDTO, existingDirector);
                _directorRepository.Update(updatedDirector);
                if (await _directorRepository.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            try
            {
                var existingDirector = await _directorRepository.GetDirectorById(id);
                if (existingDirector == null)
                {
                    return NotFound($"Could not find a director with id {id}");
                }

                _directorRepository.Delete(existingDirector);
                if (await _directorRepository.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {exception.Message}");
            }
            return BadRequest();
        }
    }
}
