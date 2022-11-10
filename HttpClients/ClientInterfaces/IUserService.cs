using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
}