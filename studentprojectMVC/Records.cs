using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace studentprojectMVC
{
    public partial class Records
    {
        public int RecordId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Details { get; set; }
        public string History { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool RecordOfTheWeek { get; set; }
        public int GenreId { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}
