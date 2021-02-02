namespace NetFlixGo.DTOs
{
    public record UpdateUserDto
    {
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public string EMail { get; init; }
        public string Password { get; init; }
    }
}