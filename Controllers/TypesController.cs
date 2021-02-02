using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetFlixGo.DTOs;
using NetFlixGo.Repositories;
using Type = NetFlixGo.Entities.Type;

namespace NetFlixGo.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TypesController : ControllerBase
    {
        private readonly ITypeRepository _repository;

        public TypesController(ITypeRepository repository)
        {
            _repository = repository;
        }

        // GET /types
        [HttpGet]
        public async Task<IEnumerable<TypeDto>> GetTypesAsync()
        {
            var types = (await _repository.GetTypesAsync()).Select(type => type.AsDto());
            return types;
        }

        // GET /types/typeId
        [HttpGet("{typeId}")]
        public async Task<ActionResult<TypeDto>> GetTypeAsync(Guid typeId)
        {
            var type = await _repository.GetTypeAsync(typeId);

            if (type is null) return NotFound();
            return type.AsDto();
        }

        // POST /types
        [HttpPost]
        public async Task<CreatedAtActionResult> CreateTypeAsync(CreateTypeDto typeDto)
        {
            Type type = new()
            {
                Id = Guid.NewGuid(),
                Name = typeDto.Name
            };

            await _repository.CreateTypeAsync(type);


            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(GetTypeAsync), new {typeId = type.Id}, type.AsDto());
        }

        // PUT /types/{typeId}
        [HttpPut("{typeId}")]
        public async Task<ActionResult> UpdateTypeAsync(Guid typeId, UpdateTypeDto typeDto)
        {
            var existingType = _repository.GetTypeAsync(typeId);
            if (existingType is null) return NotFound();

            var updatedType = await existingType with
            {
                Name = typeDto.Name
            };

            await _repository.UpdateTypeAsync(updatedType);
            return NoContent();
        }

        // Delete /types/{typeId}
        [HttpDelete("{typeId}")]
        public async Task<ActionResult> DeleteTypeAsync(Guid typeId)
        {
            var existingType = await _repository.GetTypeAsync(typeId);
            if (existingType is null) return NotFound();
            await _repository.DeleteTypeAsync(typeId);
            return NoContent();
        }
    }
}