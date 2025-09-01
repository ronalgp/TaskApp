using TaskApp.API.Models;

namespace TaskApp.API.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}
