using System.Collections.Generic;
using System.Linq;
using CoolestMovieAPI.HATEOAS;
using CoolestMovieAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CoolestMovieAPI.Controllers
{
    public class HateoasGenresControllerBase : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        public HateoasGenresControllerBase(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
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

        internal GenreDTO HateoasGetAllMethodLinks(GenreDTO genreDto)
        {
            genreDto.Links.Add(UrlLink("_self", "GetGenreByIdAsync", new { id = genreDto.GenreID }));

            return genreDto;
        }

        internal GenreDTO HateoasGetSingleMethodLinks(GenreDTO genreDto)
        {
            genreDto.Links.Add(UrlLink("all", "GetAllGenre", null));
            genreDto.Links.Add(UrlLink("_self", "GetGenreByIdAsync", new { id = genreDto.GenreID }));
            genreDto.Links.Add(UrlLinkCrud("_update", "GetGenreByIdAsync", "UpdateGenre", new { id = genreDto.GenreID }));
            genreDto.Links.Add(UrlLinkCrud("_delete", "GetGenreByIdAsync", "DeleteGenre", new { id = genreDto.GenreID }));

            return genreDto;
        }
    }
}
