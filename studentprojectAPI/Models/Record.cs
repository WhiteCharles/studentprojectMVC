using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Models
{
    public class Record
    {
        [Key]
        public Guid RecordId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        public string Details { get; set; }
        public string History { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool RecordOfTheWeek { get; set; }
        //public bool IsAvailable { get; set; }
        public Guid GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}