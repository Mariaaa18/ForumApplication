using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared;
using Shared.DTOs;

namespace Application.Logic;

public class UserLogic:IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao; 
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User(dto.UserName, dto.Password, dto.Age);
       
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }

    public Task DeleteAsync(int id)
    {
        return userDao.DeleteAsync(id);
    }

    public Task<IEnumerable<User>> GetAsync()
    {
        return userDao.GetAsync();
    }
    
    private void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.Password;
        int age = userToCreate.Age;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");

        if (password.Length < 5)
            throw new Exception("Password must be at least 5 characteres!!!");
        if (age < 13)
        {
            throw new Exception("YOU should be over 13");
        }

    }
    
}