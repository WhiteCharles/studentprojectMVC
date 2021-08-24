using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Models
{
    public class Genre
    {
        [Key]
        public Guid GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
        public string MainCategory { get; set; }
        public string Description { get; set; }
        public List<Record> Records { get; set; }
    }
}