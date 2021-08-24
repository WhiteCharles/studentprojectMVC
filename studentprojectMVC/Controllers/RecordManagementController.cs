using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentprojectMVC.Models;
using studentprojectMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using studentprojectMVC.Services;

namespace studentprojectMVC.Controllers
{
    [Authorize(Roles = "Administrators")]
    [Authorize(Policy = "DeleteRecord")]
    public class RecordManagementController : Controller
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IGenreRepository _genreRepository;

        public RecordManagementController(IRecordRepository recordRepository, IGenreRepository genreRepository)
        {
            _recordRepository = recordRepository;
            _genreRepository = genreRepository;
        }

        public ViewResult Index()
        {
            var records = _recordRepository.AllRecords.OrderBy(r => r.RecordId);
            return View(records);
        }

        public IActionResult AddRecord()
        {
            var genres = _genreRepository.AllGenres;
            var recordEditViewModel = new RecordEditViewModel
            {
                Genres = genres.Select(c => new SelectListItem() { Text = c.GenreName, Value = c.GenreId.ToString() }).ToList(),
                GenreId = genres.FirstOrDefault().GenreId
            };
            return View(recordEditViewModel);
        }

        [HttpPost]
        public IActionResult AddRecord(RecordEditViewModel recordEditViewModel)
        {
            //Basic validation
            //if (ModelState.IsValid)
            //{
            //    _recordRepository.CreateRecord(recordEditViewModel.Record);
            //    return RedirectToAction("Index");
            //}

            //custom validation rules
            if (ModelState.GetValidationState("Record.Price") == ModelValidationState.Valid
                || recordEditViewModel.Record.Price < 0)
                ModelState.AddModelError(nameof(recordEditViewModel.Record.Price), "The price of a record should exceed 0");

            //if (recordEditViewModel.Record.RecordOfTheWeek && !recordEditViewModel.Record.IsAvailable)
             //   ModelState.AddModelError(nameof(recordEditViewModel.Record.RecordOfTheWeek), "Only available records should be considered for Record of the Week");

            if (ModelState.IsValid)
            {
                _recordRepository.AddRecord(recordEditViewModel.Record);
                return RedirectToAction("Index");
            }

            return View(recordEditViewModel);
        }

        //public IActionResult EditRecord([FromRoute]int recordId)
        //public IActionResult EditRecord([FromQuery]int recordId, [FromHeader] string accept)
        public IActionResult EditRecord([FromQuery] Guid recordId, [FromHeader(Name = "Accept-Language")] string accept)   // int
        {
            var genres = _genreRepository.AllGenres;

            var record = _recordRepository.AllRecords.FirstOrDefault(r => r.RecordId == recordId);

            var recordEditViewModel = new RecordEditViewModel
            {
                Genres = genres.Select(c => new SelectListItem() { Text = c.GenreName, Value = c.GenreId.ToString() }).ToList(),
                Record = record,
                GenreId = record.GenreId
            };

            var item = recordEditViewModel.Genres.FirstOrDefault(c => c.Value == record.GenreId.ToString());
            item.Selected = true;

            return View(recordEditViewModel);
        }

        [HttpPost]
        //public IActionResult RecordPie([Bind("Record")] RecordEditViewModel recordEditViewModel)
        public IActionResult EditRecord(RecordEditViewModel recordEditViewModel)
        {
            recordEditViewModel.Record.GenreId = recordEditViewModel.GenreId;

            if (ModelState.IsValid)
            {
                _recordRepository.UpdateRecord(recordEditViewModel.Record);
                return RedirectToAction("Index");
            }
            return View(recordEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteRecord(string recordId)
        {
            return View();
        }

        public IActionResult QuickEdit()
        {
            var recordTitles = _recordRepository.AllRecords.Select(r => r.Title).ToList();
            return View(recordTitles);
        }

        [HttpPost]
        public IActionResult QuickEdit(List<string> recordTitles)
        {
            return View();
        }

        public IActionResult BulkEditRecords()
        {
            var recordTitles = _recordRepository.AllRecords.ToList();
            return View(recordTitles);
        }

        [HttpPost]
        public IActionResult BulkEditRecords(List<Record> records)
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckIfRecordTitleAlreadyExists([Bind(Prefix = "Record.Title")] string title)
        {
            var record = _recordRepository.AllRecords.FirstOrDefault(r => r.Title == title);
            return record == null ? Json(true) : Json("That record title already exists in the database");
        }
    }
}