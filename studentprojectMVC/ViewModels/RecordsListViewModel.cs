﻿using studentprojectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.ViewModels
{
    public class RecordsListViewModel
    {
        //public RecordsListViewModel(IEnumerable<Record> records, string currentGenre)
        //{
        //    Records = records;
        //    CurrentGenre = currentGenre;
        //}

        public IEnumerable<Record> Records { get; set; }
        public string CurrentGenre { get; set; }
    }
}
