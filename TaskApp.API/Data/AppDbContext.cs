using Microsoft.EntityFrameworkCore;
using TaskApp.API.Models;

namespace TaskApp.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskDetails> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}
