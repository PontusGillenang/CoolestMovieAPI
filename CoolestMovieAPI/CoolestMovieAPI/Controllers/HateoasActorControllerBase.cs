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
    public class HateoasActorControllerBase : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        public HateoasActorControllerBase(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
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
        internal ActorDTO HateoasMainLinks(ActorDTO actorDto)
        {
            actorDto.Links.Add(UrlLink("_self", "GetActorById", new { id = actorDto.ActorId }));
            //actorDto.Links.Add(UrlLink("all", "GetAllActors", null));

            return actorDto;
        }

        /// <summary>
        /// Custom extention method
        /// Use this method for possible further implementation sidelinks the team come up with.
        /// Can also duplicate this method to new methods with tailored links to be grouped.
        /// Wollter
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        internal ActorDTO HateoasGetSingleMethodLinks(ActorDTO actorDto)
        {
            actorDto.Links.Add(UrlLink("all", "GetAllActors", null));
            actorDto.Links.Add(UrlLink("_self", "GetActorById", new { id = actorDto.ActorId }));
            actorDto.Links.Add(UrlLinkCrud("_update", "GetActorById", "UpdateActor", new { id = actorDto.ActorId }));
            actorDto.Links.Add(UrlLinkCrud("_delete", "GetActorById", "DeleteActor", new { id = actorDto.ActorId }));

            return actorDto;
        }
    }
}
