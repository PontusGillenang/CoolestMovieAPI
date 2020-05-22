using CoolestMovieAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public interface IDirectorRepository : IBaseRepository
    {
        Task<IList<Director>> GetAllDirectors();
        Task<Director> GetDirectorById(int id);
        Task<IList<Director>> GetDirectorsByCountry(string country);
        Task<IList<Director>> GetDirectorsByName(string name);
    }
}