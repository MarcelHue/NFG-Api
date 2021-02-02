using System;
using System.ComponentModel.DataAnnotations;

namespace NetFlixGo.DTOs
{
    public record UpdateTypeDto
    {
        [Required] public Guid Id { get; init; }

        public string Name { get; init; }
    }
}