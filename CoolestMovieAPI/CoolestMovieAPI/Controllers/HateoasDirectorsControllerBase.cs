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
    public class HateoasDirectorsControllerBase : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        public HateoasDirectorsControllerBase(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
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

        internal DirectorDTO HateoasMainLinks(DirectorDTO director)
        {
            director.Links.Add(UrlLink("all", "GetAllDirectors", null));
            director.Links.Add(UrlLink("_self", "GetDirectorIdAsync", new { id = director.DirectorId }));

            return director;
        }
    }
}
