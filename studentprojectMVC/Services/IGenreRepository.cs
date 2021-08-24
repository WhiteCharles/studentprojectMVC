using studentprojectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.Services
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> AllGenres { get; }
    }
}
