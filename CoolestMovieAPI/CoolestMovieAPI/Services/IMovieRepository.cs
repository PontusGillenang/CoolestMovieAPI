using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    interface IMovieRepository
    {
        Task<IList<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<IList<Movie>> GetMovieByTitle(string title);
        Task<IList<Movie>> GetMovieByYear(int year);
        Task<IList<Movie>> GetMovieByRating(int rating);
        Task<IList<Movie>> GetByLength(TimeSpan time);
        Task<IList<Movie>> GetMoviesByActor(string firstName, string lastName);


    }
}
