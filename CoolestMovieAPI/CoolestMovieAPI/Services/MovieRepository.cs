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
            var query = _movieContext.Movies
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
                    Id = x.mmd.m.MovieID,                  
                    Director = x.d,                    
                }).Where(d => d.Director.DirectorName == name);
            //var categorizedProducts = product
            //        .Join(productcategory, 
            //          p => p.Id, 
            //          pc => pc.ProdId, 
            //          (p, pc) => new { p, pc })
            //        .Join(category, 
            //          ppc => ppc.pc.CatId, 
            //          c => c.Id, 
            //          (ppc, c) => new { ppc, c })
            //        .Select(m => new {
            //        ProdId = m.ppc.p.Id, // or m.ppc.pc.ProdId
            //        CatId = m.c.CatId
                                        // other assignments
            //});
            //IQueryable<MovieDirector> query = _movieContext.MovieDirectors
            //    .Include(d => d.Movie.MovieID).Where(m => m.Director.DirectorName == name);
            return await query.ToListAsync();
        }

        public async Task<IList<Movie>> GetMovieByGenre(string Genre)
        {
            
            var genre = _context.Genre.Where(g => g.GenreType == Genre).Include(x => x.MovieGenre).FirstOrDefault();
           
            return await _context.Movies.Include(x => x.MovieGenre).Where(m => m.MovieGenre == genre).ToListAsync();
        }
    }
}
