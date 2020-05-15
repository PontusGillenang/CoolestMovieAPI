using CoolestMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public interface IActorRepository : IBaseRepository
    {
        Task<IList<Actor>> GetAllActors();
        Task<Actor> GetActorsById(int id);
        Task<IList<Actor>> GetActorsByName(string firstName, string lastName);
        Task<IList<Actor>> GetAllActorsByCountry(string country);




    }
}
