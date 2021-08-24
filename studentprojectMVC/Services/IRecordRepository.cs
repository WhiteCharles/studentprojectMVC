using studentprojectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.Services
{
    public interface IRecordRepository
    {
        IEnumerable<Record> AllRecords { get; }
        IEnumerable<Record> RecordsOfTheWeek { get; }
        Record GetRecordById(Guid recordId);   // int

        //void AddRecord(Record record);
        //void UpdateRecord(Record record);
        //// General
        //void Add<T>(T entity) where T : class;
        //void Delete<T>(T entity) where T : class;
        //Task<bool> SaveChangesAsync();

        //// Records
        //Task<Record[]> GetAllRecordsAsync(bool includeGenres = false); 
        //Task<Record> GetRecordAsync(string moniker, bool includeGenres = false);

        void AddRecord(Record record);
        void UpdateRecord(Record record);
    }
}
