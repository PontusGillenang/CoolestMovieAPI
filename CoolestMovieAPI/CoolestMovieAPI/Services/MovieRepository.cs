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
            
            //string connectionString = _configuration["Database:ConnectionString"];
            //string databaseName = _configuration["Database:Database"];
           

        }
        
       public async Task<IList<Movie>> GetAllMovies()          
       {
            return await _context.Movies.Where(_ => true).ToListAsync();                               
       }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.Where(m => m.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Movie>> GetMovieByTitle(string title)
        {
            return await _context.Movies.Where(m => m.Title == title).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByYear(int year)
        {
            return await _context.Movies.Where(m => m.ReleaseYear == year).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByRating(int rating)
        {
            return await _context.Movies.Where(m => m.Rating == rating).ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByGenre(string genre)
        {
            
            return await _context.Movies.Where(m => m.Genre == genre).ToListAsync();
        }

        public async Task<IList<Movie>> GetByLength(TimeSpan time)
        {
            return await _context.Movies.Where(m => m.Length == time).ToListAsync();
        }
    }
}
