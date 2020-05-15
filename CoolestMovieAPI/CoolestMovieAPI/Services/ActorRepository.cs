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
        public async Task<Actor> GetActorsById(int id)
        {
            return await _movieContext.Actors.SingleOrDefaultAsync(x => x.ActorID == id);
        }

        public async Task<IList<Actor>> GetActorsByName(string name)
        {
            string firstName, lastName;
            NewMethod(name, out firstName, out lastName);

            return await _movieContext.Actors.Where(x => x.FirstName.ToLower() == firstName.ToLower() && x.LastName == lastName).ToListAsync();
        }

        private static void NewMethod(string name, out string firstName, out string lastName)
        {
            var names = name.Split(' ');
            firstName = names[0];
            lastName = names[1];
        }

        public async Task<IList<Actor>> GetActorsByFirstName(string firstName)
        {
            return await _movieContext.Actors.Where(x => x.FirstName.ToLower() == firstName.ToLower()).ToListAsync();
        }
        public async Task<IList<Actor>> GetActorsByLastName(string lastName)
        {
            return await _movieContext.Actors.Where(x => x.LastName.ToLower() == lastName.ToLower()).ToListAsync();
        }

        public async Task<IList<Actor>> GetAllActors()
        {
            return await _movieContext.Actors.Where(x => true).ToListAsync();
        }

        public async Task<IList<Actor>> GetAllActorsByCountry(string country)
        {
            return await _movieContext.Actors.Where(x => x.ActorCountry.ToLower() == country.ToLower()).ToListAsync();
        }

    }
}
