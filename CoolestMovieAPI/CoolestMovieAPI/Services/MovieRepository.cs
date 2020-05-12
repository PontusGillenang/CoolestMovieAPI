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
    public class MovieRepository : BaseRepository, IMovieRepository
    {       
        public MovieRepository(MovieContext movieContext, IConfiguration configuration, ILogger<MovieRepository> logger) : base (movieContext, logger)
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

        public async Task<IList<Movie>> GetMovieByRating(int rating)
        {
            return await _movieContext.Movies.Where(m => m.MovieRating == rating).ToListAsync();
        }
    
        public async Task<IList<Movie>> GetByLength(TimeSpan time)
        {
            return await _movieContext.Movies.Where(m => m.MovieLength == time).ToListAsync();
        }

        public async Task<IList<Movie>> GetMoviesByActor(string firstName, string lastName)
        {
            return await _movieContext.Movies.Where(m => m.MovieID == 1).ToListAsync();
        }

    }
}
