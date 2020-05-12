using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoolestMovieAPI.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;
        private ConfigurationRoot _configuration;

        public MovieRepository(MovieContext context, IConfiguration configuration)
        {
            _configuration = configuration as ConfigurationRoot;
            _context = context;                               
        }
        
       public async Task<IList<Movie>> GetAllMovies()          
       {
            return await _context.Movies.Where(_ => true).ToListAsync();                               
       }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.Where(m => m.MovieID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Movie>> GetMovieByTitle(string title)
        {
            return await _context.Movies.Where(m => m.MovieTitle == title).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByYear(int year)
        {
            return await _context.Movies.Where(m => m.MovieReleaseYear == year).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByRating(int rating)
        {
            return await _context.Movies.Where(m => m.MovieRating == rating).ToListAsync();
        }
    
        public async Task<IList<Movie>> GetByLength(TimeSpan time)
        {
            return await _context.Movies.Where(m => m.MovieLength == time).ToListAsync();
        }

        public async Task<IList<Movie>> GetMoviesByActor(string firstName, string lastName)
        {
            return await _context.Movies.Where(m => m.MovieID == 1).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByGenre(Genre Genre)
        {
            return await _context.Movies.Where(m=>m.MovieGenre==Genre).ToListAsync();
        }
    }
}
