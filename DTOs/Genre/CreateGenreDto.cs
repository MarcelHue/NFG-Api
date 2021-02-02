using System.ComponentModel.DataAnnotations;

namespace NetFlixGo.DTOs
{
    public record CreateGenreDto
    {
        [Required] public string Name { get; init; }
    }
}