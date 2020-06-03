using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public interface IMovieRepository : IBaseRepository
    {
        Task<IList<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<IList<Movie>> GetMovieByTitle(string title);
        Task<IList<Movie>> GetByActor(string actorName);
        Task<IList<Movie>> GetByDirector(string name);
        Task<IList<Movie>> GetMoviesByYear(int year);
        Task<IList<Movie>> GetMoviesByYearGreaterThan(int year);
        Task<IList<Movie>> GetMoviesByYearLessThan(int year);
        Task<IList<Movie>> GetMoviesByYearSpan(int year, int maxYear);
        Task<IList<Movie>> GetMoviesByRating(double rating);
        Task<IList<Movie>> GetMoviesByRatingGreaterThan(double rating);
        Task<IList<Movie>> GetMoviesByRatingLessThan(double rating);
        Task<IList<Movie>> GetMoviesByRatingSpan(double year, double maxRating);
        Task<IList<Movie>> GetMoviesByLength(TimeSpan length);
        Task<IList<Movie>> GetMoviesByLengthGreaterThan(TimeSpan length);
        Task<IList<Movie>> GetMoviesByLengthLessThan(TimeSpan length);
        Task<IList<Movie>> GetMoviesByLengthSpan(TimeSpan length, TimeSpan maxLength);
        Task<IList<Movie>> GetMoviesByGenre(string name);
    }
}
