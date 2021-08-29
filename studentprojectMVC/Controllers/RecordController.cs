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

        //public ViewResult List(string genre)
        //{
        //    string _genre = genre;  // addition 29-8

        //    IEnumerable<Record> records;

        //    string currentGenre = string.Empty;  // string currentGenre;

        //    if (string.IsNullOrEmpty(genre))
        //    {
        //        records = _recordRepository.AllRecords.OrderBy(r => r.RecordId);
        //        currentGenre = "All Available Records";
        //    }
        //    else // 29-08 added else statements
        //    {
        //        if (string.Equals("Classical", _genre, StringComparison.OrdinalIgnoreCase))
        //        {
        //            records = _recordRepository.AllRecords.Where(r => r.Genre.GenreName.Equals("Classical")).OrderBy(r => r.RecordId);
        //        }
        //        else if (string.Equals("Contemporary", _genre, StringComparison.OrdinalIgnoreCase))
        //        {
        //            records = _recordRepository.AllRecords.Where(r => r.Genre.GenreName.Equals("Contemporary")).OrderBy(r => r.RecordId);
        //        }
        //        else if (string.Equals("Jazz", _genre, StringComparison.OrdinalIgnoreCase))
        //        {
        //            records = _recordRepository.AllRecords.Where(r => r.Genre.GenreName.Equals("Jazz")).OrderBy(r => r.RecordId);
        //        }
        //        currentGenre = _genre; // 29/08
        //                               // 29-08 records = _recordRepository.AllRecords.Where(g => g.Genre.GenreName == genre).OrderBy(r => r.RecordId);
        //                               // 29-08 currentGenre = _genreRepository.AllGenres.FirstOrDefault(g => g.GenreName == genre)?.GenreName;  // FirstOrDefault(c => c.GenreName == genre)?.GenreName;

        //        // original ==> currentGenre = _genreRepository.AllGenres.FirstOrDefault(g => g.GenreName == genre)?.GenreName;
        //        //foreach (var item in records)
        //        //{
        //        //    currentGenre = _genreRepository.AllGenres.Where(g => g.GenreName == genre);
        //        //}
        //        //}
        //        var RecordsListViewModel = new RecordsListViewModel //(records, currentGenre) // 29-08
        //        {
        //            //Records = records,
        //            CurrentGenre = currentGenre
        //        };
        //        return View(RecordsListViewModel);
        //        //return View(new RecordsListViewModel) // 29-08
        //        //{ // 29-08
        //        //    Records = records, // 29-08
        //        //    CurrentGenre = currentGenre // 29-08
        //        //}); // 29-08
        //    }
        //}
        public ViewResult List(string genre)
        {
            IEnumerable<Record> records;
            string currentGenre;

            if (string.IsNullOrEmpty(genre))
            {
                records = _recordRepository.AllRecords.OrderBy(p => p.RecordId);
                currentGenre = "All available genres";
            }
            else
            {
                currentGenre = _genreRepository.AllGenres.FirstOrDefault(c => c.GenreName == genre)?.GenreName;
                records = _recordRepository.AllRecords.Where(p => p.Genre.GenreName == currentGenre)
                    .OrderBy(p => p.RecordId);
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