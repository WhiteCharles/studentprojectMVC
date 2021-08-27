using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.DTOmodels
{
    public class GenreDTO
    {
        //public Guid GenreId { get; set; } // not exposed to API
        public string GenreName { get; set; }
        public string MainCategory { get; set; }
    }
}
