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
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieContext _context;

        public DirectorRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task<IList<Director>> GetAllDirectors()
        {
            return await _context.Directors.Where(_ => true).ToListAsync();
        }

        public async Task<Director> GetDirectorById(int id)
        {
            return await _context.Directors.Where(d => d.DirectorID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Director>> GetDirectorsByName(string name)
        {
            return await _context.Directors.Where(d => d.DirectorName == name).ToListAsync();
        }

        public async Task<IList<Director>> GetDirectorsByCountry(string country)
        {
            return await _context.Directors.Where(d => d.DirectorCountry == country).ToListAsync();
        }
    }
}
