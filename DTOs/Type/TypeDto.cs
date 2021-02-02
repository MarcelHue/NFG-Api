using System;

namespace NetFlixGo.DTOs
{
    public record TypeDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}