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
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _repository;

        public GenresController(IGenreRepository repository)
        {
            _repository = repository;
        }

        // GET /genres
        [HttpGet]
        public async Task<IEnumerable<GenreDto>> GetGenresAsync()
        {
            var genres = (await _repository.GetGenresAsync()).Select(genre => genre.AsDto());
            return genres;
        }

        // GET /genres/genreId
        [HttpGet("{genreId}")]
        public async Task<ActionResult<GenreDto>> GetGenreAsync(Guid genreId)
        {
            var genre = await _repository.GetGenreAsync(genreId);

            if (genre is null) return NotFound();
            return genre.AsDto();
        }

        // POST /genres
        [HttpPost]
        public async Task<CreatedAtActionResult> CreateGenreAsync(CreateGenreDto genreDto)
        {
            Genre genre = new()
            {
                Id = Guid.NewGuid(),
                Name = genreDto.Name
            };

            await _repository.CreateGenreAsync(genre);


            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(GetGenreAsync), new {genreId = genre.Id}, genre.AsDto());
        }

        // PUT /genres/{genreId}
        [HttpPut("{genreId}")]
        public async Task<ActionResult> UpdateGenreAsync(Guid genreId, UpdateGenreDto genreDto)
        {
            var existingGenre = _repository.GetGenreAsync(genreId);
            if (existingGenre is null) return NotFound();

            var updatedGenre = await existingGenre with
            {
                Name = genreDto.Name
            };

            await _repository.UpdateGenreAsync(updatedGenre);
            return NoContent();
        }

        // Delete /genres/{genreId}
        [HttpDelete("{genreId}")]
        public async Task<ActionResult> DeleteGenreAsync(Guid genreId)
        {
            var existingGenre = await _repository.GetGenreAsync(genreId);
            if (existingGenre is null) return NotFound();
            await _repository.DeleteGenreAsync(genreId);
            return NoContent();
        }
    }
}