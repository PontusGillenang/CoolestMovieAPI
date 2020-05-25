using System;
using System.Collections.Generic;
using System.Text;

namespace CoolestMovieAPI.HATEOAS
{
        public abstract class HateoasLinkBase
        {
            public List<Link> Links { get; set; } = new List<Link>();
        }
}
