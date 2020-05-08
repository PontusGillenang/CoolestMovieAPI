using CoolestMovieAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoolestTrailerAPI.Services
{
    public interface ITrailerRepository
    {
        Task<Trailer> GetTrailerById(int id);
        Task<IList<Trailer>> GetAllTrailers();
        Task<IList<Trailer>> GetAllTrailersFor(string sName);
        Task<IList<Trailer>> GetTrailerByTitle(string title);
        //Task<IList<Trailer>> GetTrailersForMovieAndActor(string sMovieTitle, string sActor);
    }
}