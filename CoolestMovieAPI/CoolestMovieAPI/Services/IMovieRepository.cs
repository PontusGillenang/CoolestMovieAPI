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
        Task<IList<Movie>> GetMovieByYear(int year);
        Task<IList<Movie>> GetMovieByRating(double rating);
        Task<IList<Movie>> GetByLength(TimeSpan movieLength);
        


    }
}
