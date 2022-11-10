using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<ICollection<PostTitleDto>> GetAsync();
    Task<Post> GetByTitleAsync(string tittle);
    Task CreateAsync(PostCreationDto dto);
}