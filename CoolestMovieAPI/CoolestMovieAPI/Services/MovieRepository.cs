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
            

           //IQueryable <MovieDTO> query2 = _movieContext.Movies
           //     .Join(_movieContext.MovieDirectors,
           //     m => m.MovieID,
           //     md => md.Movie.MovieID,
           //     (m, md) => new { m, md }
           //     )
                
           //     .Join(_movieContext.Directors,
           //     mmd => mmd.md.Director.DirectorID,
           //     d => d.DirectorID,
           //     (mmd, d) => new { mmd, d }
           //     )
                
           //     .Join(_movieContext.MovieGenre,
           //     m => m.mmd.m.MovieID,
           //     mg => mg.Movie.MovieID,
           //     (m, mg) => new { m, mg})
                
           //     .Join(_movieContext.Genres,
           //     mmg => mmg.mg.Genre.GenreID,
           //     g => g.GenreID,
           //     (mmg, g) => new { mmg, g})
                
           //     .Select(x => new MovieDTO
           //     {
           //         id = x.mmg.m.mmd.m.MovieID,
           //         title = x.mmg.m.mmd.m.MovieTitle,
           //         Director = x.mmg.m.d,
           //         genres = x.g
           //     })
           //     .Where(d => d.Director.DirectorName == name);
            
            return await query.ToListAsync();
        }
    }
}
