using System;

namespace NetFlixGo.DTOs
{
    public record GenreDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}