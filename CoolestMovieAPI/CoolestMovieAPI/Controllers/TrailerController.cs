using CoolestTrailerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using CoolestMovieAPI.Models; // New

namespace CoolestMovieAPI.Controllers
{
    public class TrailerController : ControllerBase
    {
        private readonly TrailerRepository _trailerRepository;  // singleton used to acces member functions.

        
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
        public Task<Trailer> getAllTrailers()
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
        public Task<Trailer> GetTrailerByTitle(string sTitle)
        {
            return _trailerRepository.GetTrailerByTitle(sTitle);
        }

        //-----------------------------------------------------------------------------
        //  GetAllTrailersFor
        //-----------------------------------------------------------------------------	
        [HttpGet("sTitle={title}")]
        public Task<Trailer> GetAllTrailersFor(string sTitle)
        {
            return _trailerRepository.GetAllTrailersFor(sTitle);
        }

        //-----------------------------------------------------------------------------
        // GetTrailersForMovieAndActor
        //-----------------------------------------------------------------------------	
        [HttpGet("sTitle={title}")]
        public Task<Trailer> GetTrailersForMovieAndActor(string sMovieTitle, string sActor)
        {
            return _trailerRepository.GetTrailersForMovieAndActor(sMovieTitle, sActor); // WiP
        }
    }
}