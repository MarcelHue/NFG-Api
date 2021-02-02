using System;
using System.ComponentModel.DataAnnotations;

namespace NetFlixGo.DTOs
{
    public record CreateMovieDto
    {
        [Required] public string Title { get; init; }

        public string Description { get; init; }
        public int Year { get; init; }
        public Guid UserId { get; init; }
        public Guid TypeId { get; init; }
        public Guid[] GenreId { get; init; }
    }
}