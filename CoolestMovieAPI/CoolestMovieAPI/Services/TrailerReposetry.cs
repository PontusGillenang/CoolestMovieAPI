using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestTrailerAPI.Services
{
    public class TrailerRepository : BaseRepository, ITrailerRepository
    {
        private MovieContext _dbContext;
        public TrailerRepository(MovieContext movieContext, ILogger<TrailerRepository> logger) : base(movieContext, logger)
        { 
            _dbContext = movieContext;
        }

        public async Task<IList<Trailer>> GetAllTrailers()
        {
            return await _dbContext.Trailers.Where(_ => true).ToListAsync();
        }
						
        public async Task<Trailer> GetTrailerById(int id)
        {
            return await _dbContext.Trailers.Where(m => m.TrailerID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Trailer>> GetTrailerByTitle(string title)
        {
            return await _dbContext.Trailers.Where(m => m.TrailerTitle == title).ToListAsync();
        }

        public async Task<IList<Trailer>> GetAllTrailersFor(string sName)
        {
            return await _dbContext.Trailers.Where(m => m.TrailerTitle == sName).ToListAsync();
        }
    }
}
