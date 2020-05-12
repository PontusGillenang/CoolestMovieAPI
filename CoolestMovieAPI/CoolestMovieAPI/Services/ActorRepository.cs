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
    public class ActorRepository : BaseRepository, IActorRepository 
    {
        private readonly MovieContext _context;
        private ConfigurationRoot _configuration;

        public ActorRepository(MovieContext movieContext, IConfiguration configuration, ILogger<ActorRepository> logger) :base(movieContext,logger)
        {
            _configuration = configuration as ConfigurationRoot;
            _context = movieContext;

        }
        public async Task<Actor> GetActorsById(int id)
        {
            return await _context.Actors.SingleOrDefaultAsync(x => x.ActorID == id);
        }

        public async Task<IList<Actor>> GetActorsByName(string name)
        {
            return await _context.Actors.Where(x => x.ActorName.ToLower() == name.ToLower()).ToListAsync();
        }

        public async Task<IList<Actor>> GetAllActors()
        {
            return await _context.Actors.Where(x => true).ToListAsync();
        }

        public async Task<IList<Actor>> GetAllActorsByCountry(string country)
        {
            return await _context.Actors.Where(x => x.ActorCountry.ToLower() == country.ToLower()).ToListAsync();
        }
    }
}
