using System;
using System.Collections.Generic;
using System.Text;

namespace studentprojectLIB.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public List<Record> Records { get; set; }
    }
}