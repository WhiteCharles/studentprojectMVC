using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RecordRepository> _logger;

        public RecordRepository(AppDbContext appDbContext, ILogger<RecordRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IEnumerable<Record> AllRecords
        {
            get
            {
                try
                {
                    return _appDbContext.Records.Include(c => c.Genre);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex,$"The function '{nameof(AllRecords)}' throws an exception.");
                    return Enumerable.Empty<Record>();
                }
            }
        }

        public IEnumerable<Record> RecordsOfTheWeek
        {
            get
            {
                try
                {
                    return _appDbContext.Records.Include(c => c.Genre).Where(r => r.RecordOfTheWeek);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"The function '{nameof(RecordsOfTheWeek)}' throws an exception.");
                    return Enumerable.Empty<Record>();
                }
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
            try
            {
                //return _appDbContext.Records.Include(r => r.RecordReviews).FirstOrDefault(r => r.RecordId == recordId);
                return _appDbContext.Records.FirstOrDefault(r => r.RecordId == recordId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"The function '{nameof(GetRecordById)}' throws an exception with param: {recordId}.", recordId);
                return null;
            }
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
