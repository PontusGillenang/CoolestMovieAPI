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
            return await _context.Movie.Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
