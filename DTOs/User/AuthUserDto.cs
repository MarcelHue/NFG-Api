using System;

namespace NetFlixGo.DTOs
{
    public record AuthUserDto
    {
        public Guid Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public string EMail { get; init; }
        public string Password { get; init; }
        public string token { get; init; }
    }
}