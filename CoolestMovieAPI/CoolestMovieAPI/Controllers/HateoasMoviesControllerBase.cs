using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using CoolestMovieAPI.HATEOAS;
using CoolestMovieAPI.DTO;
using CoolestMovieAPI.Pagination;
using System;
using Microsoft.AspNetCore.WebUtilities;

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

        internal Link UrlLinkCrud(string relation, string routeName, string crudRouteName, object values)
        {
            var route = _routes.FirstOrDefault(f => f.AttributeRouteInfo.Name == routeName);
            var crudRoute = _routes.FirstOrDefault(f => f.AttributeRouteInfo.Name == crudRouteName);
            var method = crudRoute.ActionConstraints.OfType<HttpMethodActionConstraint>().First().HttpMethods.First();
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
            movieDto.Links.Add(UrlLinkCrud("_update", "GetIdAsync", "UpdateItem", new { id = movieDto.MovieID }));
            movieDto.Links.Add(UrlLinkCrud("_delete", "GetIdAsync", "DeleteItem", new { id = movieDto.MovieID }));
            return movieDto;
        }

        internal Dictionary<string, Uri> GetPaginationLinks(PaginationParameters paginationParameters, int totalMovieCount)
        {
            // Intatiate the link list
            var linkList = new Dictionary<string, Uri>();

            // Get the number of pages with current pageSize
            var pageCount = totalMovieCount > 0
                ? (int) Math.Ceiling(totalMovieCount/(double) paginationParameters.PageSize)
                : 0;

            // Create the base URL
            string baseUrl = string.Concat(
                    Request.Scheme,
                    "://",
                    Request.Host.ToUriComponent(),
                    Request.PathBase.ToUriComponent(),
                    Request.Path.ToUriComponent());



            // Create first page link
            var parameters = new Dictionary<string, string>() { { "pageNumber", "1" } };
            parameters.Add("pageSize", $"{paginationParameters.PageSize}");

            var newUrl = new Uri(QueryHelpers.AddQueryString(baseUrl, parameters));

            linkList.Add("First page", newUrl);



            // Create last page link
            parameters = new Dictionary<string, string>() { { "pageNumber", $"{pageCount}" } };
            parameters.Add("pageSize", $"{paginationParameters.PageSize}");

            newUrl = new Uri(QueryHelpers.AddQueryString(baseUrl, parameters));

            linkList.Add("Last page", newUrl);



            // Create previous page link
            if (paginationParameters.PageNumber > 1)
            {
                parameters = new Dictionary<string, string>() { { "pageNumber", $"{paginationParameters.PageNumber - 1}" } };
                parameters.Add("pageSize", $"{paginationParameters.PageSize}");

                newUrl = new Uri(QueryHelpers.AddQueryString(baseUrl, parameters));

                linkList.Add("Previous page", newUrl);
            }



            // Create next page link
            if (paginationParameters.PageNumber < pageCount)
            {
                parameters = new Dictionary<string, string>() { { "pageNumber", $"{paginationParameters.PageNumber + 1}" } };
                parameters.Add("pageSize", $"{paginationParameters.PageSize}");

                newUrl = new Uri(QueryHelpers.AddQueryString(baseUrl, parameters));

                linkList.Add("Next page", newUrl);
            }
            return linkList;
        }


        
    }
}
