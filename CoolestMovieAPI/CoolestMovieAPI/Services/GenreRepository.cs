using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(MovieContext movieContext, ILogger<ActorRepository> logger) : base(movieContext, logger)
        {
        }

        public async Task<IList<Genre>> GetAllGenres()
        {
            var query = _movieContext.Genre;

            _logger.LogInformation($"Getting all Genre.");

            return await query.ToListAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            _logger.LogInformation($"Getting single genre by id: {id}.");

            return await _movieContext.Genre.Where(g => g.GenreID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Genre>> GetGenreByName(string name)
        {
            _logger.LogInformation($"Getting genre by name: {name}.");

            return await _movieContext.Genre.Where(g => g.GenreType.Contains(name)).ToListAsync();
        }
    }
}
