using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolHive.Modules.Users.Domain.Users;

namespace SchoolHive.Modules.Users.Infrastructure.Users;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName).HasMaxLength(200);

        builder.Property(u => u.LastName).HasMaxLength(200);

        builder.Property(u => u.Email).HasMaxLength(300);

        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasIndex(u => u.IdentityId).IsUnique();
    }
}

