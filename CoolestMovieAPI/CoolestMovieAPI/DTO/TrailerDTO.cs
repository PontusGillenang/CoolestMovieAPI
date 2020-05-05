using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestTrailerAPI.DTO
{
    public class TrailerDTO
    {
        public string sTitle { get; set; }  // Specific char introduction
        //public int iPK_ID { get; set; }
        //public int iFK_MovieID { get; set; }
        public string sUrl { get; set; }
        public int iLenght { get; set; } // in seconds

    }
}
