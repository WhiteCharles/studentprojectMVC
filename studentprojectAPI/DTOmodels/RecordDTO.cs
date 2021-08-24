using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.DTOmodels
{
    public class RecordDTO
    {
        public Guid RecordId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Details { get; set; }
        public string History { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool RecordOfTheWeek { get; set; }
        //public bool IsAvailable { get; set; }
        public Guid GenreId { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}
