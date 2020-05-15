﻿using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoolestMovieAPI.Services
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {       
        public MovieRepository(MovieContext movieContext, ILogger<MovieRepository> logger) : base (movieContext, logger)
        {
                                                    
        }
        
       public async Task<IList<Movie>> GetAllMovies()          
       {
            return await _movieContext.Movies.Where(_ => true).ToListAsync();                               
       }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _movieContext.Movies.Where(m => m.MovieID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Movie>> GetMovieByTitle(string title)
        {
            return await _movieContext.Movies.Where(m => m.MovieTitle == title).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByYear(int year)
        {
            return await _movieContext.Movies.Where(m => m.MovieReleaseYear == year).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByRating(double rating)
        {
            return await _movieContext.Movies.Where(m => m.MovieRating == rating).ToListAsync();
        }
    
        public async Task<IList<Movie>> GetByLength(TimeSpan movieLength)
        {
            return await _movieContext.Movies.Where(m => m.MovieLength == movieLength).ToListAsync();
        }

        public async Task<IList<MovieDTO>> GetByDirector(string name)
        {
            IQueryable<MovieDTO> query = _movieContext.Movies
                .Join(_movieContext.MovieDirectors,
                m => m.MovieID,
                md => md.Movie.MovieID,
                (m, md) => new { m, md }
                )
                .Join(_movieContext.Directors,
                mmd => mmd.md.Director.DirectorID,
                d => d.DirectorID,
                (mmd, d) => new { mmd, d }
                ).Select(x => new MovieDTO
                {
                    id = x.mmd.m.MovieID,
                    title = x.mmd.m.MovieTitle,
                    Director = x.d,                    
                })
                .Where(d => d.Director.DirectorName == name);           
            
            return await query.ToListAsync();
        }

        public async Task<IList<MovieDTO>> GetByActor(string name)
        {

            var names = name.Split(' ');
            var firstName = names[0];
            var lastName = names[1];

            IQueryable<MovieDTO> query2 = _movieContext.Movies
                   .Join(_movieContext.MovieActors,
                   m => m.MovieID,
                   ma => ma.Movie.MovieID,
                   (m, ma) => new { m, ma }
                   )
                   .Join(_movieContext.Actors,
                   mma => mma.ma.Actor.ActorID,
                   a => a.ActorID,
                   (mma, a) => new { mma, a }
                   ).Select(x => new ActorDTO
                   {
                       id = x.a.ActorID,
                       firstName = x.a.FirstName,
                       lastName = x.a.LastName,
                       role = x.mma.ma.Role,
                       movie = x.mma.m,
                       //Denna är typ överflödig. 
                       //Och om vi bara skulle mappa till dtos i andra dtos bör vi se över detta / ändra på properties.
                       roll = new Dictionary<string, Movie>() { { x.mma.ma.Role, x.mma.m } }
                   })
                   .Where(a => a.firstName == firstName&& a.lastName ==lastName)
                   .Select(y => new MovieDTO
                   {
                        id = y.movie.MovieID,
                        title = y.movie.MovieTitle,
                        description = y.movie.MovieDescription,
                        cast = new Dictionary<string, ActorDTO>() { { y.role, y } }
                   });

                   
            return await query2.ToListAsync();

        }

        
    }
}
