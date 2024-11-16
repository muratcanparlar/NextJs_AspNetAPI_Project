using Ginosis.Common.Application.Data;
using Microsoft.EntityFrameworkCore;
using SchoolHive.Modules.Users.Domain.Users;
using SchoolHive.Modules.Users.Infrastructure.Users;

namespace SchoolHive.Modules.Users.Infrastructure.Databaase;
public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

