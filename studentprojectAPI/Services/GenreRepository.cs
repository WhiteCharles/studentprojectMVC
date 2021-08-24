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
        private readonly AppDbContext _appDbContext;

        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Genre> AllGenres => _appDbContext.Genres;

        public void AddGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            // the repository fills the id (instead of using identity columns)
            genre.GenreId = Guid.NewGuid();

            foreach (var record in genre.Records)
            {
                record.GenreId = Guid.NewGuid();
            }

            _appDbContext.Genres.Add(genre);
        }

        public bool GenreExists(Guid genreId)
        {
            if (genreId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genreId));
            }

            return _appDbContext.Genres.Any(g => g.GenreId == genreId);
        }

        public void DeleteGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            _appDbContext.Genres.Remove(genre);
        }

        public IEnumerable<Genre> GetGenre(Guid genreId)
        {
            if (genreId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genreId));
            }

            return _appDbContext.Genres.Where(g => g.GenreId == genreId);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _appDbContext.Genres.ToList<Genre>();
        }

        public IEnumerable<Genre> GetGenres(GenresResourceParameters genresResourceParameters)
        {
            if (genresResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(genresResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(genresResourceParameters.MainCategory)
                 && string.IsNullOrWhiteSpace(genresResourceParameters.SearchQuery))
            {
                return GetGenres();
            }

            var collection = _appDbContext.Genres as IQueryable<Genre>;

            if (!string.IsNullOrWhiteSpace(genresResourceParameters.MainCategory))
            {
                var mainCategory = genresResourceParameters.MainCategory.Trim();
                collection = collection.Where(g => g.MainCategory == mainCategory);
            }

            if (!string.IsNullOrWhiteSpace(genresResourceParameters.SearchQuery))
            {

                var searchQuery = genresResourceParameters.SearchQuery.Trim();
                collection = collection.Where(g => g.MainCategory.Contains(searchQuery)
                    || g.MainCategory.Contains(searchQuery)
                    || g.GenreName.Contains(searchQuery));
            }

            return collection.ToList();
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

        public IEnumerable<Genre> GetGenres(IEnumerable<Guid> genreIds)
        {
            if (genreIds == null)
            {
                throw new ArgumentNullException(nameof(genreIds));
            }

            return _appDbContext.Genres.Where(g => genreIds.Contains(g.GenreId))
                .OrderBy(g => g.MainCategory)
                .OrderBy(g => g.GenreName)
                .OrderBy(g => g.Records)
                .ToList();
        }

        public void UpdateGenre(Genre genre)
        {
            _appDbContext.Genres.Update(genre);
            _appDbContext.SaveChanges();
        }
    }
}

