﻿using SchoolHive.Modules.Users.Domain.Users;
using SchoolHive.Modules.Users.Infrastructure.Databaase;

namespace SchoolHive.Modules.Users.Infrastructure.Users;

internal class UserRepository(UsersDbContext usersDbContext) : IUserRepository
{
    public void Insert(User user)
    {
        usersDbContext.Add(user);
    }
}

