using System.Collections.Generic;
using System.Threading.Tasks;
using CoolestMovieAPI.Models;

namespace CoolestMovieAPI.Services
{
    public interface IMovieDirectorsRepository : IBaseRepository
    {
        Task<IList<MovieDirector>> GetAllMovieDirectors();
        Task<Movie> GetMovieById(int id);
        Task<Director> GetDirectorById(int id);
    }
}