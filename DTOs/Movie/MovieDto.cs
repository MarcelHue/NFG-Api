using System;

namespace NetFlixGo.DTOs
{
    public record MovieDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int Year { get; init; }
        public Guid UserId { get; init; }
        public Guid TypeId { get; init; }
        public Guid[] GenreId { get; init; }
    }
}