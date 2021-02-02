using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetFlixGo.DTOs;
using NetFlixGo.Entities;
using NetFlixGo.Repositories;

namespace NetFlixGo.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repository;

        public MoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }

        // GET /movies
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
        {
            var movies = (await _repository.GetMoviesAsync()).Select(movie => movie.AsDto());
            return movies;
        }

        // GET /movies/movieId
        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(Guid movieId)
        {
            var movie = await _repository.GetMovieAsync(movieId);

            if (movie is null) return NotFound();
            return movie.AsDto();
        }

        // POST /movies
        [HttpPost]
        public async Task<CreatedAtActionResult> CreateMovieAsync(CreateMovieDto movieDto)
        {
            Movie movie = new()
            {
                Id = Guid.NewGuid(),
                Title = movieDto.Title,
                Description = movieDto.Description,
                Year = movieDto.Year,
                UserId = movieDto.UserId,
                TypeId = movieDto.TypeId,
                GenreId = movieDto.GenreId
            };

            await _repository.CreateMovieAsync(movie);


            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(GetMovieAsync), new {movieId = movie.Id}, movie.AsDto());
        }

        // PUT /movies/{movieId}
        [HttpPut("{movieId}")]
        public async Task<ActionResult> UpdateMovieAsync(Guid movieId, UpdateMovieDto movieDto)
        {
            var existingMovie = _repository.GetMovieAsync(movieId);
            if (existingMovie is null) return NotFound();

            var updatedMovie = await existingMovie with
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Year = movieDto.Year,
                UserId = movieDto.UserId,
                TypeId = movieDto.TypeId,
                GenreId = movieDto.GenreId
            };

            await _repository.UpdateMovieAsync(updatedMovie);
            return NoContent();
        }

        // Delete /movies/{movieId}
        [HttpDelete("{movieId}")]
        public async Task<ActionResult> DeleteMovieAsync(Guid movieId)
        {
            var existingMovie = await _repository.GetMovieAsync(movieId);
            if (existingMovie is null) return NotFound();
            await _repository.DeleteMovieAsync(movieId);
            return NoContent();
        }
    }
}