using System.ComponentModel.DataAnnotations;

namespace NetFlixGo.DTOs
{
    public record CreateTypeDto
    {
        [Required] public string Name { get; init; }
    }
}