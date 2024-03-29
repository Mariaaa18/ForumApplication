﻿using Shared;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<User?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task<IEnumerable<User>> GetAsync();
}
    