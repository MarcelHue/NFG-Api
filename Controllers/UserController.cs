using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetFlixGo.DTOs;
using NetFlixGo.Entities;
using NetFlixGo.Repositories;

namespace NetFlixGo.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET /users/userId
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid userId)
        {
            var user = await _repository.GetUserAsync(userId);

            if (user is null) return NotFound();
            return user.AsDto();
        }

        // POST /users
        [HttpPost]
        public async Task<CreatedAtActionResult> CreateUserAsync(CreateUserDto userDto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                EMail = userDto.EMail,
                Password = userDto.Password
            };

            await _repository.CreateUserAsync(user);


            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(GetUserAsync), new {userId = user.Id}, user.AsDto());
        }

        // PUT /users/{userId}
        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUserAsync(Guid userId, UpdateUserDto userDto)
        {
            var existingUser = _repository.GetUserAsync(userId);
            if (existingUser is null) return NotFound();

            var updatedUser = await existingUser with
            {
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                EMail = userDto.EMail,
                Password = userDto.Password
            };

            await _repository.UpdateUserAsync(updatedUser);
            return NoContent();
        }

        // PUT /users/{userId}/favorites
        [HttpPut("{userId}/favorites")]
        public async Task<ActionResult> UpdateUserFavoritesAsync(Guid userId, Guid[] favorites)
        {
            var existingUser = _repository.GetUserAsync(userId);
            if (existingUser is null) return NotFound();

            var updatedUser = await existingUser with
            {
                favorites = favorites
            };

            await _repository.UpdateUserAsync(updatedUser);
            return NoContent();
        }


        // Delete /users/{userId}
        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUserAsync(Guid userId)
        {
            var existingUser = await _repository.GetUserAsync(userId);
            if (existingUser is null) return NotFound();
            await _repository.DeleteUserAsync(userId);
            return NoContent();
        }

        // authenticate user
        [HttpPost("authenticate/")]
        public async Task<ActionResult<AuthUserDto>> AuthUserAsync(toAuthUserDto toAuthUser)
        {
            var user = await _repository.AuthUserAsync(toAuthUser);
            if (user is null) return NotFound();
            return user.addTokenToDto();
        }
    }
}