using TaskApp.API.Models;

namespace TaskApp.API.Interfaces;

public interface IUserRepository
{
    Task<bool> EmailExists(string email);
    Task Register(User user);
    Task<User> FetchUser(string email);
}
