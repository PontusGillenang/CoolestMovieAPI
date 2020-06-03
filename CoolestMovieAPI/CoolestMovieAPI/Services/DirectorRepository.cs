using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public class DirectorRepository : BaseRepository, IDirectorRepository
    {
        public DirectorRepository(MovieContext movieContext, ILogger<DirectorRepository> logger) : base(movieContext, logger)
        {}

        public async Task<IList<Director>> GetAllDirectors()
        {
            _logger.LogInformation("Getting all directors in order of their id.");
            IQueryable<Director> query = _movieContext.Directors
                                            .OrderBy(director => director.DirectorID);
            
            return await query.ToListAsync();
        }

        public async Task<Director> GetDirectorById(int id)
        {
            _logger.LogInformation($"Getting director with id: {id}");
            IQueryable<Director> query = _movieContext.Directors
                                            .Include(movieDirector => movieDirector.MovieDirectors)
                                            .ThenInclude(movie => movie.Movie)
                                            .Where(director => director.DirectorID == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<Director>> GetDirectorsByName(string name)
        {
            _logger.LogInformation($"Getting directors with the name: {name}");
            IQueryable<Director> query = _movieContext.Directors
                                            .Include(movieDirector => movieDirector.MovieDirectors)
                                            .ThenInclude(movie => movie.Movie)
                                            .Where(director => director.DirectorName.Contains(name))
                                            .OrderBy(director => director.DirectorID);

            return await query.ToListAsync();
        }

        public async Task<IList<Director>> GetDirectorsByCountry(string country)
        {
            _logger.LogInformation($"Getting directors from the country: {country}");
            IQueryable<Director> query = _movieContext.Directors
                                            .Include(movieDirector => movieDirector.MovieDirectors)
                                            .ThenInclude(movie => movie.Movie)
                                            .Where(director => director.DirectorCountry.Contains(country))
                                            .OrderBy(director => director.DirectorID);

            return await query.ToListAsync();            
        }
    }
}
