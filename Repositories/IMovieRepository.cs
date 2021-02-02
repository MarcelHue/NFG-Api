using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetFlixGo.Entities;

namespace NetFlixGo.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(Guid movieId);
        Task CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Guid movieId);
    }
}