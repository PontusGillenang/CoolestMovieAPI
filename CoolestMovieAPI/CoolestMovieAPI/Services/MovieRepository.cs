using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
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
        {}
        
       public async Task<IList<Movie>> GetAllMovies()          
       {
            _logger.LogInformation($"Getting all movies!");
            
            var query = await _movieContext.Movies
                .ToListAsync();

            return query;
       }

        public async Task<Movie> GetMovieById(int id)
        {
            _logger.LogInformation($"Getting movie by Id: {id}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieID == id)
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMovieByTitle(string title)
        {
            _logger.LogInformation($"Getting movie by title: {title}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieTitle == title)
                .ToListAsync();

            return query;
        }

        public async Task<IList<MovieDTO>> GetByDirector(string name)
        {
            _logger.LogInformation($"Getting movies by director: {name}");

            var query = await _movieContext.Movies
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
                .Where(d => d.Director.DirectorName == name)
                .ToListAsync();

            return query;
        }

        public async Task<IList<MovieDTO>> GetByActor(string actorName)
        {                    
            var query = await _movieContext.Movies
                   .Join(_movieContext.MovieActors,
                   m => m.MovieID,
                   ma => ma.Movie.MovieID,
                   (m, ma) => new { m, ma }
                   )
                   .Join(_movieContext.Actors,
                   mma => mma.ma.Actor.ActorID,
                   a => a.ActorID,
                   (mma, a) => new { mma, a }
                   ).Select(x => new ActorDTO
                   {
                       ActorId = x.a.ActorID,
                       ActorName = x.a.ActorName,
                       Role = x.mma.ma.Role,
                       Movie = x.mma.m,
                       //Denna är typ överflödig. 
                       //Och om vi bara skulle mappa till dtos i andra dtos bör vi se över detta / ändra på properties.
                       Roll = new Dictionary<string, Movie>() { { x.mma.ma.Role, x.mma.m } }
                   })
                   .Where(a => a.ActorName == actorName)
                   .Select(y => new MovieDTO
                   {
                        id = y.Movie.MovieID,
                        title = y.Movie.MovieTitle,
                        description = y.Movie.MovieDescription,
                        cast = new Dictionary<string, ActorDTO>() { { y.Role, y } }
                   }).ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByYear(int year)
        {
            _logger.LogInformation($"Getting movie by year: {year}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieReleaseYear == year)
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByYearGreaterThan(int year)
        {
            _logger.LogInformation($"Getting movie by year greater than: {year}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieReleaseYear >= year)
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByYearLessThan(int year)
        {
            _logger.LogInformation($"Getting movie by year less than: {year}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieReleaseYear <= year)
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByYearSpan(int year, int maxYear)
        {
            _logger.LogInformation($"Getting movie by yearspan: {year} - {maxYear}");

            var query = await _movieContext.Movies
                .Where(m => (m.MovieReleaseYear >= year && m.MovieReleaseYear <= maxYear))
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByRating(double rating)
        {
            _logger.LogInformation($"Getting movie by rating: {rating}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieRating == rating)
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByRatingGreaterThan(double rating)
        {
            _logger.LogInformation($"Getting movie by rating greater than: {rating}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieRating >= rating)
                .ToListAsync();

            return query; 
        }

        public async Task<IList<Movie>> GetMoviesByRatingLessThan(double rating)
        {
            _logger.LogInformation($"Getting movie by rating less than: {rating}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieRating <= rating)
                .ToListAsync();

            return query; 
        }

        public async Task<IList<Movie>> GetMoviesByRatingSpan(double rating, double maxRating)
        {
            _logger.LogInformation($"Getting movie by ratingspan: {rating} - {maxRating}");

            var query = await _movieContext.Movies
                .Where(m => (m.MovieRating >= rating && m.MovieRating <= maxRating))
                .ToListAsync();

            return query; 
        }
    
        public async Task<IList<Movie>> GetMoviesByLength(TimeSpan length)
        {
            _logger.LogInformation($"Getting movie by length: {length}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieLength == length)
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByLengthGreaterThan(TimeSpan length)
        {
            _logger.LogInformation($"Getting movie by length greater than: {length}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieLength >= length)
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByLengthLessThan(TimeSpan length)
        {
            _logger.LogInformation($"Getting movie by length less than: {length}");

            var query = await _movieContext.Movies
                .Where(m => m.MovieLength <= length)
                .ToListAsync();

            return query;
        }

        public async Task<IList<Movie>> GetMoviesByLengthSpan(TimeSpan length, TimeSpan maxLength)
        {
            _logger.LogInformation($"Getting movies by lengthspan: {length} - {maxLength}");

            var query = await _movieContext.Movies
                .Where(m => (m.MovieLength >= length && m.MovieLength <= maxLength))
                .ToListAsync();

            return query;
        }
    }
}
