using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace EfcDataAccesss.DAOs;

public class UserEfcDao:IUserDao
{
    private readonly ForumContext context;

    public UserEfcDao(ForumContext context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName.ToLower().Equals(userName.ToLower())
        );
        return existing;;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? existing= await context.Users.FindAsync(id);
        return existing;
    }

    public async Task DeleteAsync(int id)
    {
        User? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"User with  id{id} not found");
        }

        context.Users.Remove(existing);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        IQueryable<User> usersQuery = context.Users.AsQueryable();
        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }
}