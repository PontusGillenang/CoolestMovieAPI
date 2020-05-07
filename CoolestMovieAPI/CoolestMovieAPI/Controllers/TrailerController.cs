using CoolestTrailerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using CoolestMovieAPI.Models; // New
using CoolestMovieAPI.MovieDbContext;// New

namespace CoolestMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TrailersController : ControllerBase
    {
        private readonly ITrailerRepository _trailerRepository;  // singleton used to acces member functions.

        public TrailersController(MovieContext context)
        {
            _trailerRepository = new TrailerRepository(context);
        }

        //  //-----------------------------------------------------------------------------
        //  // DUMMY
        //  //-----------------------------------------------------------------------------			
        //  [HttpGet("DUMMY={title}")]
        //  public Task<Trailer> GetByTitle(int DUMMY)
        //  {
        //      return _trailerRepository.GetByTitle(DUMMY);
        //  }



        //-----------------------------------------------------------------------------
        //  getAllTrailers
        //-----------------------------------------------------------------------------	
        [HttpGet]
        public Task<IList<Trailer>> GetAll()
        {
            return _trailerRepository.GetAllTrailers();
        }

        //-----------------------------------------------------------------------------
        //  GetTrailerById
        //-----------------------------------------------------------------------------	
        [HttpGet("{id}")]
        public Task<Trailer> GetById(int id)
        {
            return _trailerRepository.GetTrailerById(id);
        }

        //-----------------------------------------------------------------------------
        //  GetTrailerByTitle
        //-----------------------------------------------------------------------------	
        [HttpGet("sTitle={title}")]
        public Task<IList<Trailer>> GetTrailerByTitle(string sTitle)
        {
            return _trailerRepository.GetTrailerByTitle(sTitle);
        }

        //-----------------------------------------------------------------------------
        //  GetAllTrailersFor
        //-----------------------------------------------------------------------------	
        [HttpGet("sTitle={title}")]
        public Task<IList<Trailer>> GetAllTrailersFor(string sTitle)
        {
            return _trailerRepository.GetAllTrailersFor(sTitle);
        }

        ////-----------------------------------------------------------------------------
        //// GetTrailersForMovieAndActor
        ////-----------------------------------------------------------------------------	
        //[HttpGet("sTitle={title}")]
        //public Task<Trailer> GetTrailersForMovieAndActor(string sMovieTitle, string sActor)
        //{
        //    return _trailerRepository.GetTrailersForMovieAndActor(sMovieTitle, sActor); // WiP
        //}
    }
}