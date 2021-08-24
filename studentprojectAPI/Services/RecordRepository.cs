using Microsoft.EntityFrameworkCore;
using studentprojectAPI.DbContexts;
using studentprojectAPI.Models;
using studentprojectAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Services
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
                return _appDbContext.Records.Include(r => r.Genre);
            }
        }

        public IEnumerable<Record> RecordsOfTheWeek
        {
            get
            {
                return _appDbContext.Records.Include(r => r.Genre).Where(r => r.RecordOfTheWeek);
            }
        }

        //public void AddRecord(Record record)
        //{
        //    _appDbContext.Records.Add(record);
        //    _appDbContext.SaveChanges();
        //}
        public void AddRecord(Guid genreId, Record record)
        {
            if (genreId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genreId));
            }

            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
            // always set the AuthorId to the passed-in authorId
            record.GenreId = genreId;
            _appDbContext.Records.Add(record);
            _appDbContext.SaveChanges();
        }

        public void DeleteRecord(Record record)
        {
            _appDbContext.Records.Remove(record);
            _appDbContext.SaveChanges();
        }


        public IEnumerable<Record> GetRecords()
        {
            return _appDbContext.Records;
        }

        public Record GetRecordById(Guid recordId)
        {
            //return _appDbContext.Records.Include(r => r.RecordReviews).FirstOrDefault(r => r.RecordId == recordId);
            return _appDbContext.Records.FirstOrDefault(r => r.RecordId == recordId);
        }
        
        public Record GetRecord(Guid genreId, Guid recordId)
        {
            if (genreId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genreId));
            }

            if (recordId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(recordId));
            }

            return _appDbContext.Records
              .Where(r => r.GenreId == genreId && r.RecordId == recordId).FirstOrDefault();
        }

        public IEnumerable<Record> GetRecord(Guid genreId)
        {
            if (genreId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genreId));
            }

            return _appDbContext.Records
                        .Where(r => r.GenreId == genreId)
                        .OrderBy(r => r.Title).ToList();
        }

        
        public void UpdateRecord(Record record)
        {
            _appDbContext.Records.Update(record);
            _appDbContext.SaveChanges();
        }

        

        public bool Save()
        {
            return (_appDbContext.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}


