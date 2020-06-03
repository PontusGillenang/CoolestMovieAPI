using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public interface IActorRepository : IBaseRepository
    {
        Task<IList<Actor>> GetAllActors();
        Task<Actor> GetActorsById(int id);
        Task<IList<Actor>> GetActorsByName(string name);

        Task<IList<Actor>> GetActorsByCountry(string country);
        Task<IList<ActorDTO>> GetActorsByMovie(string movieTitle);
    }
}
