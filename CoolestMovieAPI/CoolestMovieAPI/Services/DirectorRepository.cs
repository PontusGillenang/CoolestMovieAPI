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
    public class DirectorRepository : BaseRepository, IDirectorRepository
    {
        public DirectorRepository(MovieContext movieContext, ILogger<DirectorRepository> logger) : base(movieContext, logger)
        {}

        public async Task<IList<Director>> GetAllDirectors()
        {
            _logger.LogInformation("Getting directors");
            IQueryable<Director> query = _movieContext.Directors.Where(_ => true);
            
            return await query.ToListAsync();
        }

        public async Task<Director> GetDirectorById(int id)
        {
            return await _movieContext.Directors.Where(d => d.DirectorID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Director>> GetDirectorsByName(string name)
        {
            return await _movieContext.Directors.Where(d => d.DirectorName == name).ToListAsync();
        }

        public async Task<IList<Director>> GetDirectorsByCountry(string country)
        {
            return await _movieContext.Directors.Where(d => d.DirectorCountry == country).ToListAsync();
        }
    }
}
