using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.DTOmodels
{
    public class RecordDTO
    {
        // public Guid RecordId { get; set; }  // not exposed to API
        public string Title { get; set; }  
        public string Artist { get; set; }
        public string Details { get; set; }
        public string History { get; set; }
        // public string ImageUrl { get; set; }  // not exposed to API
        // public string ImageThumbnailUrl { get; set; }  // not exposed to API
        public bool RecordOfTheWeek { get; set; }
        //public bool IsAvailable { get; set; }  // not exposed to API
        // public Guid GenreId { get; set; }  // not exposed to API
        public GenreDTO Genre { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}
