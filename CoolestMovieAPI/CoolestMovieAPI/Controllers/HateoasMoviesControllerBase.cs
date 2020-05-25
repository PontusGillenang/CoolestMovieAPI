using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using CoolestMovieAPI.HATEOAS;
using CoolestMovieAPI.DTO;

namespace CoolestMovieAPI.Controllers
{
    public class HateoasMoviesControllerBase : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        public HateoasMoviesControllerBase(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _routes = actionDescriptorCollectionProvider.ActionDescriptors.Items;
        }

        internal Link UrlLink(string relation, string routeName, object values)
        {
            var route = _routes.FirstOrDefault(f => f.AttributeRouteInfo.Name == routeName);
            var method = route.ActionConstraints.OfType<HttpMethodActionConstraint>().First().HttpMethods.First();
            var url = Url.Link(routeName, values).ToLower();
            return new Link(url, relation, method);
        }

        /// <summary>
        /// Use this method for your mainlinks. Eg CRUD, just add
        /// more links to your CRUD methods inside
        /// Wollter
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        internal MovieDTO HateoasGetAllMethodLinks(MovieDTO movie)
        {
            MovieDTO movieDto = movie;

            movieDto.Links.Add(UrlLink("_self", "GetIdAsync", new { id = movieDto.MovieID }));

            return movieDto;
        }

        /// <summary>
        /// Custom extention method
        /// Use this method for possible further implementation sidelinks the team come up with.
        /// Can also duplicate this method to new methods with tailored links to be grouped.
        /// Wollter
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        internal MovieDTO HateoasGetSingleMethodLinks(MovieDTO movie)
        {
            MovieDTO movieDto = movie;

            movieDto.Links.Add(UrlLink("all", "GetAll", null));
            movieDto.Links.Add(UrlLink("_self", "GetIdAsync", new { id = movieDto.MovieID }));
            //movieDto.Links.Add(UrlLink("_updateSelf", "UpdateItem", new { id = movieDto.MovieID }));
            //movieDto.Links.Add(UrlLink("_deleteSelf", "DeleteItem", new { id = movieDto.MovieID }));
            return movieDto;
        }
    }
}
