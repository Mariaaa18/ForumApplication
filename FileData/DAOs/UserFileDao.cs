using Application.DaoInterfaces;
using Shared;


namespace FileData.DAOs;

public class UserFileDao:IUserDao
{
    
    private readonly FileContext context;
    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u => u.UserName.Equals(
            userName,  StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);


    }

    public Task<User?> GetByIdAsync(int id)
    {
        
        User? existing = context.Users.FirstOrDefault(u =>
            u.Id == id
        );
        return Task.FromResult(existing);
    }

    public Task DeleteAsync(int id)
    {
        User? existing = context.Users.FirstOrDefault(p => p.Id ==id);
        if (existing == null)
        {
            throw new Exception($"User with id {id} does not exist!");
        }

        context.Users.Remove(existing); 
        context.SaveChanges();
    
        return Task.CompletedTask;
    }

    public Task<IEnumerable<User>> GetAsync()
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        return Task.FromResult(users);
    }

    public Task<User> UpdateAsync(User toUpdate)
    {
        User? existing = context.Users.FirstOrDefault(todo => todo.Id == toUpdate.Id);
        if (existing == null)
        {
            throw new Exception($"Todo with id {toUpdate.Id} does not exist!");
        }

        context.Users.Remove(existing);
        context.Users.Add(toUpdate);
    
        context.SaveChanges();
    
        return Task.FromResult(existing);
    }
}