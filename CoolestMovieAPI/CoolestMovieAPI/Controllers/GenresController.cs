using AutoMapper;
using Castle.Core.Internal;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class GenresController : HateoasGenresControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenresController(IGenreRepository genreRepository, IMapper mapper, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
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

                IEnumerable<GenreDTO> mappedResults = _mapper.Map<IList<GenreDTO>>(results);
                IEnumerable<GenreDTO> hateoasResults = mappedResults.Select(m => HateoasGetAllMethodLinks(m));

                if (mappedResults.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hateoasResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetGenreByIdAsync")]
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
                    return Ok(HateoasGetSingleMethodLinks(mappedResult));
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpPost(Name = "CreateGenre")]
        [Authorize]
        public async Task<ActionResult<GenreDTO>> PostGenre(GenreDTO genreDTO)
        {
            try
            {
                var mappedEntity = _mapper.Map<Genre>(genreDTO);
                _genreRepository.Add(mappedEntity);
                
                if(await _genreRepository.Save())
                {
                    return Created($"/api/v1.0/genres/{mappedEntity.GenreID}", _mapper.Map<GenreDTO>(mappedEntity));
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure, cannot create item. {e.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{genreid}", Name = "UpdateGenre")]
        [Authorize]
        public async Task<ActionResult> PutGenre(int genreid, GenreDTO genreDTO)
        {
            try
            {
                var oldGenre = await _genreRepository.GetGenreById(genreid);
               
                if(oldGenre == null)
                {
                    return NotFound($"Could not find any genre with id: {genreid}");
                }

                var newGenre = _mapper.Map(genreDTO, oldGenre);
                _genreRepository.Update(newGenre);

                if(await _genreRepository.Save())
                {
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure, could not update item. {e.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{genreid}", Name = "DeleteGenre")]
        [Authorize]
        public async Task<ActionResult> DeleteGenre(int genreid)
        {
            try
            {
                var oldGenre = await _genreRepository.GetGenreById(genreid);
                
                if(oldGenre == null)
                {
                    return NotFound($"Could not find any genre with id: {genreid}");
                }

                _genreRepository.Delete(oldGenre);

                if(await _genreRepository.Save())
                {
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure, could not delete item. {e.Message}");
            }
            return BadRequest();
        }

    }
}
