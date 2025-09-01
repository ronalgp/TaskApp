using Microsoft.EntityFrameworkCore;
using TaskApp.API.Data;
using TaskApp.API.Interfaces;
using TaskApp.API.Models;

namespace TaskApp.API.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task Register(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task<bool> EmailExists(string email)
    {
        return await context.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<User> FetchUser(string email)
    {
        return await context.Users
        .SingleOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower())) ?? null!;
    }
}
