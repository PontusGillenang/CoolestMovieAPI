using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestTrailerAPI.Services
{
    public class TrailerRepository : ITrailerRepository
    {
        // EntityFramwork DB context -> LINQ / SQL Quary





        private MovieContext _dbContext;
        //private ConfigurationRoot _configuration;
        public TrailerRepository(MovieContext context/*, IConfiguration configuration*/)
        {
            //_configuration = configuration as ConfigurationRoot;
            _dbContext = context;
        }

        //-----------------------------------------------------------------------------
        // getAllTrailers
        //-----------------------------------------------------------------------------			
        public async Task<IList<Trailer>> GetAllTrailers()
        {
            return await _dbContext.Trailers.Where(_ => true).ToListAsync();
        }

        //-----------------------------------------------------------------------------
        // getTrailerByID
        //-----------------------------------------------------------------------------							
        public async Task<Trailer> GetTrailerById(int id)
        {
            return await _dbContext.Trailers.Where(m => m.TrailerID == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Trailer>> GetTrailerByTitle(string title)
        {
            return await _dbContext.Trailers.Where(m => m.TrailerTitle == title).ToListAsync();
        }

        public async Task<IList<Trailer>> /*GetTrailerByYear*/GetAllTrailersFor(string sName)
        {
            return await _dbContext.Trailers.Where(m => m.TrailerTitle == sName).ToListAsync();
        }

        

        ////-----------------------------------------------------------------------------
        //// GetTrailersForMovieAndActor
        ////-----------------------------------------------------------------------------							
        //public async Task<IList<Trailer>> GetTrailersForMovieAndActor(string sMovieTitle, string sActor)
        //{
        //    return await _dbContext.Trailers.Where(m => m.title == sMovieTitle && m.Actor == sActor).ToList();
        //}




    }
}
