using System.Collections.Generic;
using System.Linq;
using CoolestMovieAPI.HATEOAS;
using CoolestTrailerAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CoolestMovieAPI.Controllers
{
    public class HateoasTrailersControllerBase : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        public HateoasTrailersControllerBase(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
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

        internal TrailerDTO HateoasMainLinks(TrailerDTO trailer)
        {
            TrailerDTO trailerDto = trailer;

            trailerDto.Links.Add(UrlLink("all", "GetAllTrailers", null));

            return trailerDto;
        }

        internal TrailerDTO HateoasGetSingleMethodLinks(TrailerDTO trailerDto)
        {
            trailerDto.Links.Add(UrlLink("all", "GetAllTrailers", null));
            trailerDto.Links.Add(UrlLink("_self", "GetTrailerByIdAsync", new { id = trailerDto.MovieID }));
            trailerDto.Links.Add(UrlLinkCrud("_update", "GetTrailerByIdAsync", "UpdateTrailer", new { id = trailerDto.MovieID }));
            trailerDto.Links.Add(UrlLinkCrud("_delete", "GetTrailerByIdAsync", "DeleteTrailer", new { id = trailerDto.MovieID }));
            return trailerDto;
        }
    }
}
