using System.Collections.Generic;

namespace CoolestMovieAPI.HATEOAS
{
    public abstract class HateoasLinkBase
        {
            public List<Link> Links { get; set; } = new List<Link>();
        }
}
