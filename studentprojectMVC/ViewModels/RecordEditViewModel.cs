using Microsoft.AspNetCore.Mvc.Rendering;
using studentprojectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.ViewModels
{
    public class RecordEditViewModel
    {
        public Record Record { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public Guid GenreId { get; set; }  // int
    }
}
