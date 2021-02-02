using System.ComponentModel.DataAnnotations;

namespace NetFlixGo.DTOs
{
    public record toAuthUserDto
    {
        [Required] public string EMail { get; init; }

        [Required] public string Password { get; init; }
    }
}