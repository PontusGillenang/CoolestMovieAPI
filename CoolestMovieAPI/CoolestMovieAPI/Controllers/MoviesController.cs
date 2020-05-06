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
    public class MoviesController : ControllerBase
    { 
        private MovieRepository _repository;
        
        [HttpGet]
        public Task<Movie> GetAll()
        {
            return _repository.GetAllMovies();
        }

        [HttpGet("{id}")]
        public Task<Movie> GetById(int id)
        {
            return _repository.GetMovieById(id);
        }

        [HttpGet("title={title}")]
        public Task<Movie> GetByTitle(string title)
        {
            return _repository.GetMovieByTitle(title);
        }

        [HttpGet("year={year}")]
        public Task<Movie> GetByYear(int year)
        {
            return _repository.GetMovieByYear(year);
        }

        [HttpGet("rating={rating}")]
        public Task<Movie> GetByRating(int rating)
        {
            return _repository.GetMovieByRating(rating);
        }

        [HttpGet("genre={genre}")]
        public Task<Movie> GetByGenre(string genre)
        {
            return _repository.GetMovieByGenre(genre);
        }

        [HttpGet("length={length}")]
        public Task<Movie> GetByLength(TimeSpan time)
        {
            return _repository.GetByLength(time);
        }
    }
}
