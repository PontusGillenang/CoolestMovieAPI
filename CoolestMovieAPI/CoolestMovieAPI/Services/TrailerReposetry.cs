using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestTrailerAPI.Services
{
    public class TrailerRepository
    {
        // EntityFramwork DB context -> LINQ / SQL Quary





        private DbContext _dbContext;
        public TrailerRepository()
        {

        }

        //-----------------------------------------------------------------------------
        // getAllTrailers
        //-----------------------------------------------------------------------------			
        public async Task<Trailer> GetAllTrailers()
        {
            return await _dbContext.Model(_ => true).ToList();
        }

        //-----------------------------------------------------------------------------
        // getTrailerByID
        //-----------------------------------------------------------------------------							
        public async Task<Trailer> GetTrailerById(int id)
        {
            return await _dbContext.Trailer.Where(m => m.ID == id).FirstOrDefault();
        }

        public async Task<Trailer> GetTrailerByTitle(string title)
        {
            return await _dbContext.Trailer.Where(m => m.Title == title).ToList();
        }

        public async Task<Trailer> /*GetTrailerByYear*/GetAllTrailersFor(string sName)
        {
            return await _dbContext.Trailer.Where(m => m.Name == sName).ToList();
        }

        public async Task<Trailer> GetTrailerByRating(int rating)
        {
            return await _dbContext.Trailer.Where(m => m.Rating == rating).ToList();
        }

        public async Task<Trailer> GetTrailerByGenre(string genre)
        {

            return await _dbContext.Trailer.Where(m => m.Genre == genre).ToList();
        }

        public async Task<Trailer> GetByLength(TimeSpan time)
        {
            return await _dbContext.Trailer.Where(m => m.Length == time).ToList();
        }


        //-----------------------------------------------------------------------------
        // GetTrailersForMovieAndActor
        //-----------------------------------------------------------------------------							
        public async Task<Trailer> GetTrailersForMovieAndActor(string sMovieTitle, string sActor)
        {
            return await _dbContext.Trailer.Where(m => m.Title == sMovieTitle && m.Actor == sActor).ToList();
        }




    }
}
