using Shared;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
    Task DeleteAsync(int id);
    Task<IEnumerable<User>> GetAsync();
    
    
}