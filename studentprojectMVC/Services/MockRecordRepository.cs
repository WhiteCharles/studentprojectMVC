//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace studentprojectMVC.Services
//{
//    public class MockRecordRepository : IRecordRepository
//    {
//        private readonly IGenreRepository _genreRepository = new MockGenreRepository();

//        public IEnumerable<Record> AllRecords =>
//            new List<Record>
//            {
//                new Record {RecordId = 1, Title ="Born 2 Run", Artist = "Bruce Springsteen", Genre = _genreRepository.AllGenres.ToList()[2], RecordOfTheWeek = false, ImageThumbnailUrl=@"\images\borntorun.jpg" },
//                new Record {RecordId = 2, Title ="Cotton Club days", Artist = "Duke Ellington", Genre = _genreRepository.AllGenres.ToList()[1], RecordOfTheWeek = false, ImageThumbnailUrl=@"\images\cottonclubdays.jpg"   },
//                new Record {RecordId = 3, Title ="Colour by Numbers", Artist = "Culture Club", Genre = _genreRepository.AllGenres.ToList()[2], RecordOfTheWeek = false, ImageThumbnailUrl=@"\images\colourbynumbers.jpg"   }
//            };

//        public IEnumerable<Record> RecordsOfTheWeek { get; }

//        public void Add<T>(T entity) where T : class
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete<T>(T entity) where T : class
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Record[]> GetAllRecordsAsync(bool includeGenres = false)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Record> GetRecordAsync(string moniker, bool includeGenres = false)
//        {
//            throw new NotImplementedException();
//        }

//        public Record GetRecordById(int recordId)
//        {
//            return AllRecords.FirstOrDefault(predicate => predicate.RecordId == recordId);
//        }

//        public Task<bool> SaveChangesAsync()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
