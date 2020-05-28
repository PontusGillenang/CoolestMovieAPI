using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoolestMovieAPI.Models;

namespace CoolestMovieAPI.Services
{
    public interface IGenreRepository : IBaseRepository
    {
        Task<IList<Genre>> GetAllGenre();
        Task<Genre> GetGenreById(int id);
    }
}
