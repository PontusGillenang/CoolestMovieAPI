using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Models
{
    public class Trailer
    {
        public int iPK_ID { get; set; }
        public int iFK_MovieID { get; set; }
        public string sUrl { get; set; }
        public string sTitle { get; set; }
    }
}
