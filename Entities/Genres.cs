using System;

namespace NetFlixGo.Entities
{
    public record Genre
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}