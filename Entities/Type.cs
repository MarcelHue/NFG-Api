using System;

namespace NetFlixGo.Entities
{
    public record Type
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}