using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoolestMovieAPI.Services
{
    public class MovieDirectorsRepository : BaseRepository, IMovieDirectorsRepository
    {
        public MovieDirectorsRepository(MovieContext movieContext, ILogger<MovieRepository> logger) : base (movieContext, logger)
        {}

        public async Task<IList<MovieDirector>> GetAllMovieDirectors()
        {
                _logger.LogInformation($"Getting all MovieDirectors!");
                
                var query = await _movieContext.MovieDirectors
                        .Include(m => m.Movie)
                        .Include(d => d.Director)
                        .ToListAsync();

                return query;
        }
    }
}