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
        IEnumerable<Genre> AllGenres { get; }

        // GENRES
        IEnumerable<Genre> GetGenres();
        IEnumerable<Genre> GetGenres(GenresResourceParameters genresResourceParameters);
        IEnumerable<Genre> GetGenre(Guid genreId);
        //Genre GetGenre(Guid genreId);
        IEnumerable<Genre> GetGenres(IEnumerable<Guid> genreIds);

        void AddGenre(Genre genre);
        void DeleteGenre(Genre genre);
        void UpdateGenre(Genre genre);
        bool GenreExists(Guid genreId);

        Record GetRecord(Guid genreId, Guid recordId);
    }
}
