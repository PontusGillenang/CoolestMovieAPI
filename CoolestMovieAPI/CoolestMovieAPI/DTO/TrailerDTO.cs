using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestTrailerAPI.DTO
{
    public class TrailerDTO
    {
        public string title { get; set; }  // Specific char introduction
        //public int iPK_ID { get; set; }
        //public int iFK_MovieID { get; set; }
        public string url { get; set; }
        public int lenght { get; set; } // in seconds

    }
}
