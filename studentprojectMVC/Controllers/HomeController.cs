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
    public class HomeController : Controller
    {
        private readonly IRecordRepository _recordRepository;

        public HomeController(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                RecordsOfTheWeek = _recordRepository.RecordsOfTheWeek
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {            
            return View();
        }
    }
}
