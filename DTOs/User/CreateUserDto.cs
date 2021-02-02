using System.ComponentModel.DataAnnotations;

namespace NetFlixGo.DTOs
{
    public record CreateUserDto
    {
        [Required] public string Firstname { get; init; }

        [Required] public string Lastname { get; init; }

        [Required] public string EMail { get; init; }

        [Required] public string Password { get; init; }
    }
}