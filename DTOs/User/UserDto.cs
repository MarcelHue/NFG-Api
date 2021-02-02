using System;

namespace NetFlixGo.DTOs
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public string EMail { get; init; }
        public Guid[] favorites { get; init; }
    }
}