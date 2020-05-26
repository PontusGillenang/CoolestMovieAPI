using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Director> GetDirectorById(int id)
        {
            _logger.LogInformation($"Getting director with id: {id}");

            IQueryable<Director> query = _movieContext.Directors
                                            .Where(director => director.DirectorID == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            _logger.LogInformation($"Getting movie by Id: {id}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieID == id)
                .FirstOrDefaultAsync();

            return query;
        }

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