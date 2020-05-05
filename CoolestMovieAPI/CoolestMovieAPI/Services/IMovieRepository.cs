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
    }
}
