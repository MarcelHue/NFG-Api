using System.ComponentModel.DataAnnotations;

namespace NetFlixGo.DTOs
{
    public record UpdateGenreDto
    {
        [Required] public string Name { get; init; }
    }
}