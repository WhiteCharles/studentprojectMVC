using Microsoft.EntityFrameworkCore;
using studentprojectMVC.DbContexts;
using studentprojectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.Services
{
    public class RecordRepository : IRecordRepository
    {
        private readonly AppDbContext _appDbContext;

        public RecordRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Record> AllRecords
        {
            get
            {
                return _appDbContext.Records.Include(c => c.Genre);
            }
        }

        public IEnumerable<Record> RecordsOfTheWeek
        {
            get
            {
                return _appDbContext.Records.Include(c => c.Genre).Where(r => r.RecordOfTheWeek);
            }
        }

        //public void Add<T>(T entity) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete<T>(T entity) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Record[]> GetAllRecordsAsync(bool includeGenres = false)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Record> GetRecordAsync(string moniker, bool includeGenres = false)
        //{
        //    throw new NotImplementedException();
        //}

        //public Record GetRecordById(int recordId)
        //{
        //    return _appDbContext.Records.FirstOrDefault(r => r.RecordId == recordId);
        //}

        //public Task<bool> SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public Record GetRecordById(Guid recordId)   //
        {
            //return _appDbContext.Records.Include(r => r.RecordReviews).FirstOrDefault(r => r.RecordId == recordId);
            return _appDbContext.Records.FirstOrDefault(r => r.RecordId == recordId);
        }

        public void UpdateRecord(Record record)
        {
            _appDbContext.Records.Update(record);
            _appDbContext.SaveChanges();
        }

        public void AddRecord(Record record)
        {
            _appDbContext.Records.Add(record);
            _appDbContext.SaveChanges();
        }
    }
}
