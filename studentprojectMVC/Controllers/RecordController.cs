using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using studentprojectMVC.Models;
using studentprojectMVC.Services;
using studentprojectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace studentprojectMVC.Controllers
{
    [AllowAnonymous]
    public class RecordController : Controller
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IGenreRepository _genreRepository;

        public RecordController(IRecordRepository recordRepository, IGenreRepository genreRepository)
        {
            _recordRepository = recordRepository;
            _genreRepository = genreRepository;
        }

        //public ViewResult List()
        //{
        //    RecordsListViewModel recordsListViewModel = new RecordsListViewModel();
        //    recordsListViewModel.Records = _recordRepository.AllRecords;

        //    recordsListViewModel.CurrentGenre = "Contemporary";
        //    return View(recordsListViewModel);
        //}

        public ViewResult List(string genre)
        {
            IEnumerable<Record> records;
            string currentGenre = string.Empty;  // string currentGenre;

            if (string.IsNullOrEmpty(genre))
            {
                records = _recordRepository.AllRecords.OrderBy(r => r.RecordId);
                currentGenre = "All Available Records";
            }
            else
            {
                records = _recordRepository.AllRecords.Where(g => g.Genre.GenreName == genre)  // (p => p.Genre.GenreName == genre)
                    .OrderBy(r => r.RecordId);
                currentGenre = _genreRepository.AllGenres.FirstOrDefault(c => c.GenreName == genre).GenreName;  // FirstOrDefault(c => c.GenreName == genre)?.GenreName;
            }
            return View(new RecordsListViewModel
            {
                Records = records,
                CurrentGenre = currentGenre
            });
        }

        public IActionResult Details(Guid id)  // int
        {
            var record = _recordRepository.GetRecordById(id);
            if (record == null)
                return NotFound();
            return View(record);
        }
        //public ViewResult List()
        //{
        //    RecordsListViewModel recordsListViewModel = new RecordsListViewModel();
        //    recordsListViewModel.Records = _recordRepository.AllRecords;

        //    recordsListViewModel.CurrentGenre = "Music Genres";
        //    return View(recordsListViewModel);
        //}
    }
}