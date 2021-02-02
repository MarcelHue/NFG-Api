using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NetFlixGo.DTOs;
using NetFlixGo.Entities;
using Type = NetFlixGo.Entities.Type;

namespace NetFlixGo
{
    public static class Extensions
    {
        private const string Secret =
            "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static MovieDto AsDto(this Movie movie)
        {
            return new()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                UserId = movie.UserId,
                TypeId = movie.TypeId,
                GenreId = movie.GenreId
            };
        }

        public static TypeDto AsDto(this Type type)
        {
            return new()
            {
                Id = type.Id,
                Name = type.Name
            };
        }

        public static UserDto AsDto(this User user)
        {
            return new()
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                EMail = user.EMail,
                favorites = user.favorites
            };
        }

        public static AuthUserDto addTokenToDto(this User user)
        {
            return new()
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                EMail = user.EMail,
                Password = user.Password,
                token = GenerateToken(user.EMail)
            };
        }

        public static GenreDto AsDto(this Genre genre)
        {
            return new()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        private static string GenerateToken(string username, int expireMinutes = 20)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }
}