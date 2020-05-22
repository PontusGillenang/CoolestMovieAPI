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


        public ActorRepository(MovieContext movieContext, ILogger<ActorRepository> logger) : base(movieContext, logger)
        {
        }

        public async Task<IList<Actor>> GetAllActors()
        {
            var query = _movieContext.Actors;

            _logger.LogInformation($"Getting all actors.");

            return await query.ToListAsync();
        }

        public async Task<Actor> GetActorsById(int id)
        {
            _logger.LogInformation($"Getting actor with id {id}");

            var query = await _movieContext.Actors
                .SingleOrDefaultAsync(x => x.ActorID == id);
            return query;
        }

        public async Task<IList<Actor>> GetActorsByName(string name)
        {
            
            _logger.LogInformation($"Getting all actors named {name}");

            var query = await _movieContext.Actors
                .Where(n => n.ActorName.Contains(name))
                .OrderBy(n => n.ActorName)
                .ToListAsync();
            return query;
        }

        public async Task<IList<Actor>> GetActorsByCountry(string country)
        {
            _logger.LogInformation($"Getting all actors from {country}");

            var query = await _movieContext.Actors
                .Where(a => a.ActorCountry == country)
                .OrderBy(n => n.ActorCountry)
                .ToListAsync();
            return query;
        }
        
    }
}
