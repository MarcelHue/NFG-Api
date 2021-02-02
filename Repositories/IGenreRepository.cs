using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetFlixGo.Entities;

namespace NetFlixGo.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<Genre> GetGenreAsync(Guid genreId);
        Task CreateGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(Guid genreId);
    }
}