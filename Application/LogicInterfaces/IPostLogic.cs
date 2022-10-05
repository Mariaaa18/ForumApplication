using Shared;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<PostTitleDto>> GetTitlesAsync();
    
    Task<Post?> GetByTitleAsync(string title);

}