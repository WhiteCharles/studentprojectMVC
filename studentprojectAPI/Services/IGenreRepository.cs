using studentprojectAPI.Models;
using studentprojectAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Services
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();  // IEnumerable<Record> GetRecords();

        //IEnumerable<Genre> AllGenres { get; }
        Task<Genre> GetGenreAsync(string genreName);
        //// GENRES
        //Record GetRecord(Guid genreId, Guid recordId);
        ////IEnumerable<Genre> GetGenres();

        //IEnumerable<Genre> GetGenres(GenresResourceParameters genresResourceParameters);
        //IEnumerable<Genre> GetGenre(Guid genreId);
        ////Genre GetGenre(Guid genreId);
        //IEnumerable<Genre> GetGenres(IEnumerable<Guid> genreIds);

        void Add<T>(T entity) where T : class;
        //void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //void AddGenre(Genre genre);
        //void DeleteGenre(Genre genre);
        //void UpdateGenre(Genre genre);
        //bool GenreExists(Guid genreId);
    }
}
