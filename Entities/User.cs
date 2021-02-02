using System;

namespace NetFlixGo.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public string EMail { get; init; }
        public string Password { get; init; }
        public Guid[] favorites { get; init; }
    }
}