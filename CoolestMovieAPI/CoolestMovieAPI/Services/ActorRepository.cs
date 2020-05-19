﻿using CoolestMovieAPI.Models;
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


        public async Task<IList<Actor>> GetAllActors(string country = "")
        {

            IQueryable<Actor> query = _movieContext.Actors;

            if (country != "")
            {
                _logger.LogInformation($"Getting all actors from {country}.");
                query = query.Where(a => a.ActorCountry == country);
            }
            else
            {
                _logger.LogInformation($"Getting all actors!");
            }

            return await query.ToListAsync();
        }

        public async Task<Actor> GetActorsById(int id)
        {
            return await _movieContext.Actors.SingleOrDefaultAsync(x => x.ActorID == id);
        }

        public async Task<IList<Actor>> GetActorsByName(string name)
        {
            _logger.LogInformation($"Getting all actors named {name}");

            var query = await _movieContext.Actors
                .Where(n => n.ActorName == name)
                .ToListAsync();
            return query;
        }


        public async Task<IList<Actor>> GetAllActorsByCountry(string country)
        {
            return await _movieContext.Actors.Where(x => x.ActorCountry.ToLower() == country.ToLower()).ToListAsync();
        }
    }
}
