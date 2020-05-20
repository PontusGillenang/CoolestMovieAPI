using CoolestTrailerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using CoolestMovieAPI.Models; // New
using CoolestMovieAPI.MovieDbContext;// New
using Microsoft.AspNetCore.Http;
using Castle.Core.Internal;

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



        #region Dummy
        //  //-----------------------------------------------------------------------------
        //  // DUMMY
        //  //-----------------------------------------------------------------------------			
        //  [HttpGet("DUMMY={title}")]
        //  public Task<Trailer> GetByTitle(int DUMMY)
        //  {
        //      return _trailerRepository.GetByTitle(DUMMY);
        //  }
        #endregion

        #region old
        ////-----------------------------------------------------------------------------
        ////  getAllTrailers
        ////-----------------------------------------------------------------------------	
        //[HttpGet]                           // ASP will ctrl F for "get" inf function name, if it dosent contain that [HttpGet] points it in the right direction
        //public Task<IList<Trailer>> GetAll()
        //{
        //    return _trailerRepository.GetAllTrailers();
        //}
        #endregion



        //-----------------------------------------------------------------------------
        //  getAllTrailers
        //-----------------------------------------------------------------------------	
        [HttpGet]
        public async Task<ActionResult<IList<Trailer>>> GetAll([FromQuery]string /*sName*/ name)
        {
            try
            {
                IList<Trailer> results = await _trailerRepository.GetAllTrailers();

                if (results.IsNullOrEmpty())
                    return NotFound();

                else
                    return Ok(results);
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }

        }



        //-----------------------------------------------------------------------------
        //  GetTrailerById
        //-----------------------------------------------------------------------------	
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                Trailer results = await _trailerRepository.GetTrailerById(id);

                if (results != null)
                    return Ok(results);

                else
                    return NotFound();
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }


            //return _trailerRepository.GetTrailerById(id);
        }
        

      
        //-----------------------------------------------------------------------------
        //  GetTrailerByTitle
        //-----------------------------------------------------------------------------	
        [HttpGet("searchtitle")]
        public async Task<ActionResult<IList<Trailer>>> GetTrailerByTitle([FromQuery]string /*sName*/ name)
        {
            try
            {
                IList<Trailer> results = await _trailerRepository.GetTrailerByTitle(name);

                if (results.IsNullOrEmpty())
                    return NotFound();

                else
                    return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }



        #region Disabled
        ////-----------------------------------------------------------------------------
        ////  GetAllTrailersFor
        ////-----------------------------------------------------------------------------	
        //[HttpGet("title={sTitle}")]
        //public Task<IList<Trailer>> GetAllTrailersFor(string sTitle)
        //{
        //    return _trailerRepository.GetAllTrailersFor(sTitle);
        //}

        ////-----------------------------------------------------------------------------
        //// GetTrailersForMovieAndActor
        ////-----------------------------------------------------------------------------	
        //[HttpGet("sTitle={title}")]
        //public Task<Trailer> GetTrailersForMovieAndActor(string sMovieTitle, string sActor)
        //{
        //    return _trailerRepository.GetTrailersForMovieAndActor(sMovieTitle, sActor); // WiP
        //}
        #endregion
    }
}