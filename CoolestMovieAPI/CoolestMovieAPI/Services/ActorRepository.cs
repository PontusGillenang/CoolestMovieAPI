using CoolestMovieAPI.DTO;
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



        public async Task<IList<ActorDTO>> GetActorsByMovie(string movieTitle)
        {
            _logger.LogInformation($"Getting actors by movie: {movieTitle}");


            //var query = await _movieContext.Actors
            //.Join(_movieContext.MovieActors,
            //a => a.ActorID,
            //ma => ma.Actor.ActorID,
            //(a, ma) => new { a, ma })
            //.Join(_movieContext.Movies,
            //ama => ama.ma.Movie.MovieID,
            //m => m.MovieID,
            //(ama, m) => new { ama, m })
            //.Where(x => x.m.MovieTitle == movieTitle)
            //.Select(x => new ActorDTO
            //{
            //    ActorId = x.ama.a.ActorID,
            //    ActorName = x.ama.a.ActorName,
            //    ActorBirthDate = x.ama.a.ActorBirthDate,
            //    Role = x.ama.ma.Role,
            //})
            //.ToListAsync();

            //return query;

            var query =
            from a in _movieContext.Actors
            join ma in _movieContext.MovieActors on a.ActorID equals ma.Actor.ActorID
            join m in _movieContext.Movies on ma.Movie.MovieID equals m.MovieID
            where m.MovieTitle == movieTitle
            select new ActorDTO
            {
                ActorId = a.ActorID,
                ActorName = a.ActorName,
                ActorBirthDate = a.ActorBirthDate,
                ActorCountry = a.ActorCountry,
                Role = ma.Role
            };
            

            return await query.ToListAsync();




        }
    }
}
