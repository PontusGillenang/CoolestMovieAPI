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

        internal TrailerDTO HateoasMainLinks(TrailerDTO trailer)
        {
            TrailerDTO trailerDto = trailer;

            trailerDto.Links.Add(UrlLink("all", "GetAll", null));
            trailerDto.Links.Add(UrlLink("_self", "GetIdAsync", new { id = trailerDto.MovieID }));

            return trailerDto;
        }
    }
}
