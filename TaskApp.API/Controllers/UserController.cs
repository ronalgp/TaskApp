using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TaskApp.API.DTO;
using TaskApp.API.Models;
using TaskApp.API.Interfaces;
using TaskApp.API.Extensions;

namespace TaskApp.API.Controllers
{
    public class UserController(IUserRepository userRepository, ITokenService tokenService) : BaseController
    {
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await userRepository.EmailExists(registerDto.Email))
            {
                return BadRequest("Email is already in use.");
            }

            using var hmac = new HMACSHA256();

            var user = new User()
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                Roles = registerDto.Roles,
                HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                HashKey = hmac.Key,
            };

            await userRepository.Register(user);

            return user.ToDto(tokenService);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userRepository.FetchUser(loginDto.Email);

            if (user == null)
                return Unauthorized("Invalid email or password.");

            using var hmac = new HMACSHA256(user.HashKey);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int count = 0; count < computeHash.Length; count++)
            {
                if (computeHash[count] != user.HashPassword[count])
                    return Unauthorized("Invalid email or password.");
            }

            return user.ToDto(tokenService);
        }
    }
}
