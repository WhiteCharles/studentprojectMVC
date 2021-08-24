using System;
using System.Collections.Generic;
using System.Text;

namespace studentprojectLIB.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Details { get; set; }
        public string History { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool RecordOfTheWeek { get; set; }
        //public bool IsAvailable { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}
