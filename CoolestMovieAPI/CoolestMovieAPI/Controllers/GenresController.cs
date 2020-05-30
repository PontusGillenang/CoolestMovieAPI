using AutoMapper;
using Castle.Core.Internal;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenresController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllGenre")]
        public async Task<ActionResult<IList<GenreDTO>>> GetAll()
        {
            try
            {
                var results = await _genreRepository.GetAllGenre();
                var mappedResults = _mapper.Map<IList<GenreDTO>>(results);

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetById(int id)
        {
            try
            {
                var result = await _genreRepository.GetGenreById(id);
                var mappedResult = _mapper.Map<GenreDTO>(result);

                if (mappedResult == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mappedResult);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpPost(Name = "CreateGenre")]
        public async Task<ActionResult<GenreDTO>> PostGenre(GenreDTO genreDTO)
        {
            try
            {
                var mappedEntity = _mapper.Map<Genre>(genreDTO);
                _genreRepository.Add(mappedEntity);
                if(await _genreRepository.Save())
                {
                    return Created($"/api/v1.0/movies/{mappedEntity.GenreID}", _mapper.Map<GenreDTO>(mappedEntity));
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database faliure, cannot create item. {e.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{genreid}", Name = "UpdateGenre")]
        public async Task<ActionResult> PutGenre(int genreid, GenreDTO genreDTO)
        {
            try
            {
                var oldGenre = await _genreRepository.GetGenreById(genreid);
                if(oldGenre == null)
                {
                    return NotFound($"Could not find genre with id: {genreid}"):
                }

                var newGenre = _mapper.Map(genreDTO, oldGenre);
                _genreRepository.Update(newGenre);

                if(await _genreRepository.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database faliure, could not update item. {e.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{genreid}", Name = "DeleteGenre")]

    }
}
