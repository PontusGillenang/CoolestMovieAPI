using CoolestMovieAPI.HATEOAS;

namespace CoolestTrailerAPI.DTO
{
    public class TrailerDTO : HateoasLinkBase
    {
        public string TrailerUrl { get; set; }
        public string TrailerTitle { get; set; }
        public int MovieID { get; set; }
    }
}
