using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.Models
{
    public class Genre
    {
        [Key]
        public Guid GenreId { get; set; } // int
        [Required]
        public string GenreName { get; set; }
        public string Description { get; set; }
        public List<Record> Records { get; set; }
    }
}