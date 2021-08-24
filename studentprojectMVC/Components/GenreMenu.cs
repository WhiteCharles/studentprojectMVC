using Microsoft.AspNetCore.Mvc;
using studentprojectMVC.Models;
using studentprojectMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.Components
{
    public class GenreMenu : ViewComponent
    {
        private readonly IGenreRepository _genreRepository;
        public GenreMenu(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _genreRepository.AllGenres.OrderBy(c => c.GenreName);
            return View(genres);
        }
    }
}
