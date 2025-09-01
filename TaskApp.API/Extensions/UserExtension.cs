using System;
using TaskApp.API.DTO;
using TaskApp.API.Interfaces;
using TaskApp.API.Models;

namespace TaskApp.API.Extensions;

public static class UserExtension
{
    public static UserDto ToDto(this User user, ITokenService tokenService)
    {
        if (user == null) throw new ArgumentNullException(nameof(User));
        if (tokenService == null) throw new ArgumentNullException(nameof(tokenService));

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Roles = user.Roles,
            Token = tokenService.CreateToken(user)
        };
    }
}
