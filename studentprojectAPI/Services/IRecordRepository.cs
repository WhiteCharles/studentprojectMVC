using studentprojectAPI.Models;
using studentprojectAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Services
{
    public interface IRecordRepository
    {
        // RECORDS
        IEnumerable<Record> GetRecords();
        IEnumerable<Record> GetRecord(Guid recordId);
        Record GetRecord(Guid genreId, Guid recordId);
        Record GetRecordById(Guid recordId);

        void AddRecord(Guid genreId, Record record);
        void UpdateRecord(Record record);
        void DeleteRecord(Record record);

        IEnumerable<Record> AllRecords { get; }
        IEnumerable<Record> RecordsOfTheWeek { get; }

        bool Save();

    }
}
