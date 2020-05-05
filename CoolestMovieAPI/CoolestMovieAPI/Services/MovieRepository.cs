using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
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
        private DbContext _context;
        public MovieRepository()
        {

        }
        
       public async Task<Movie> GetAllMovies()          
       {
                                    
            return await _context.Model(_ => true).ToList();

       }

        public async Task<Movie> GetMovieById(string id)
        {
            return await _context.Movie.Where(m => m.ID == id).FirstOrDefault();
        }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            return await _context.Movie.Where(m => m.Title == title).ToList();
        }

        public async Task<Movie> GetMovieByYear(int year)
        {
            return await _context.Movie.Where(m => m.Year == year).ToList();
        }

        public async Task<Movie> GetMovieByRating(int rating)
        {
            return await _context.Movie.Where(m => m.Rating == rating).ToList();
        }

        public async Task<Movie> GetMovieByGenre(string genre)
        {
            
            return await _context.Movie.Where(m => m.Genre == genre).ToList();
        }

        public async Task<Movie> GetByLength(TimeSpan time)
        {
            return await _context.Movie.Where(m => m.Length == time).ToList();
        }
    }
}
