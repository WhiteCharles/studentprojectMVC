using studentprojectAPI.DbContexts;
using studentprojectAPI.Models;
using studentprojectAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Services
{
    public class GenreRepository : IGenreRepository
    {
        // insert data context
        private readonly AppDbContext _appDbContext;
        // data context constructor
        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET all Genres
        public async Task<IEnumerable<Genre>> GetAllGenresAsync()   // public IEnumerable<Record> GetRecords()
        {
            return _appDbContext.Genres;
        }
        
        // Get specific Genre
        public async Task<Genre> GetGenreAsync(string genreName)
        {
            IQueryable<Genre> result = _appDbContext.Genres.Include(c => c.)
            var result = _appDbContext.Genres.Where(g => g.GenreName.ToLowerInvariant() == genreName.ToLowerInvariant());
            //return await result.FirstOrDefault.FirstOrDefult(); _appDbContext.Genres.Where(g => g.GenreName == genreName);
            return await result.FirstOrDefaultAsync();

            //var result = _appDbContext.Genres.Where(g => g.GenreName.ToLowerInvariant() == genreName.ToLowerInvariant());
            ////return await result.FirstOrDefault.FirstOrDefult(); _appDbContext.Genres.Where(g => g.GenreName == genreName);
            //return await result.FirstOrDefaultAsync();
            // return result.FirstOrDefault();
        }


        public void Add<T>(T entity) where T : class
        {
            //_logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            //_logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _appDbContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //_logger.LogInformation($"Saving the changes in the database");

            // Only return success if at least one row was changed
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        //public IEnumerable<Genre> GetGenres()
        //{
        //    return _appDbContext.Genres.ToList<Genre>();
        //}
        //public IEnumerable<Genre> GetGenre(Guid genreId)
        //{
        //    if (genreId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(genreId));
        //    }
        //    return _appDbContext.Genres.Where(g => g.GenreId == genreId);
        //}
        //public Record GetGenre(Guid genreId, Guid recordId)
        //{
        //    if (genreId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(genreId));
        //    }
        //    if (recordId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(recordId));
        //    }
        //    return _appDbContext.Records
        //      .Where(r => r.GenreId == genreId && r.RecordId == recordId).FirstOrDefault();
        //}
        //public IEnumerable<Genre> GetGenres(IEnumerable<Guid> genreIds)
        //{
        //    if (genreIds == null)
        //    {
        //        throw new ArgumentNullException(nameof(genreIds));
        //    }
        //    return _appDbContext.Genres.Where(g => genreIds.Contains(g.GenreId))
        //        .OrderBy(g => g.MainCategory)
        //        .OrderBy(g => g.GenreName)
        //        .OrderBy(g => g.Records)
        //        .ToList();
        //}


        //public IEnumerable<Genre> AllGenres => _appDbContext.Genres;

        //public void AddGenre(Genre genre)
        //{
        //    if (genre == null)
        //    {
        //        throw new ArgumentNullException(nameof(genre));
        //    }

        //    // the repository fills the id (instead of using identity columns)
        //    genre.GenreId = Guid.NewGuid();

        //    foreach (var record in genre.Records)
        //    {
        //        record.GenreId = Guid.NewGuid();
        //    }

        //    _appDbContext.Genres.Add(genre);
        //}

        //public bool GenreExists(Guid genreId)
        //{
        //    if (genreId == Guid.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(genreId));
        //    }

        //    return _appDbContext.Genres.Any(g => g.GenreId == genreId);
        //}

        //public void DeleteGenre(Genre genre)
        //{
        //    if (genre == null)
        //    {
        //        throw new ArgumentNullException(nameof(genre));
        //    }

        //    _appDbContext.Genres.Remove(genre);
        //}

        ////public IEnumerable<Genre> GetGenres(GenresResourceParameters genresResourceParameters)
        ////{
        ////    if (genresResourceParameters == null)
        ////    {
        ////        throw new ArgumentNullException(nameof(genresResourceParameters));
        ////    }

        ////    if (string.IsNullOrWhiteSpace(genresResourceParameters.MainCategory)
        ////         && string.IsNullOrWhiteSpace(genresResourceParameters.SearchQuery))
        ////    {
        ////        return GetGenres();
        ////    }

        ////    var collection = _appDbContext.Genres as IQueryable<Genre>;

        ////    if (!string.IsNullOrWhiteSpace(genresResourceParameters.MainCategory))
        ////    {
        ////        var mainCategory = genresResourceParameters.MainCategory.Trim();
        ////        collection = collection.Where(g => g.MainCategory == mainCategory);
        ////    }

        ////    if (!string.IsNullOrWhiteSpace(genresResourceParameters.SearchQuery))
        ////    {

        ////        var searchQuery = genresResourceParameters.SearchQuery.Trim();
        ////        collection = collection.Where(g => g.MainCategory.Contains(searchQuery)
        ////            || g.MainCategory.Contains(searchQuery)
        ////            || g.GenreName.Contains(searchQuery));
        ////    }

        ////    return collection.ToList();
        ////}

        //public void UpdateGenre(Genre genre)
        //{
        //    _appDbContext.Genres.Update(genre);
        //    _appDbContext.SaveChanges();
        //}
    }
}

