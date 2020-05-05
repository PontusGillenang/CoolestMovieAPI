using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    interface IMovieRepository
    {
        Task<Movie> GetAllMovies();
        Task<Movie> GetMovieById(string id);
        Task<Movie> GetMovieByTitle(string title);
        Task<Movie> GetMovieByYear(int year);
        Task<Movie> GetMovieByRating(int rating);
        Task<Movie> GetMovieByGenre(string genre);
        Task<Movie> GetByLength(TimeSpan time);


    }
}
