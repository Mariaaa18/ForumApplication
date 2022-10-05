using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared;
using Shared.DTOs;

namespace Application.Logic;

public class PostLogic:IPostLogic
{
    private readonly IUserDao userDao;
    private readonly IPostDao postDao;

    public PostLogic(IUserDao userDao, IPostDao postDao)
    {
        this.userDao = userDao;
        this.postDao = postDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.IdOwner);
        if (user == null)
        {
            throw new Exception($"User with {dto.IdOwner} was not found");
        }

        ValidateTodo(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public async Task<IEnumerable<PostTitleDto>> GetTitlesAsync()
    {
        return await postDao.GetTitlesAsync();
    }

    public async Task<Post?> GetByTitleAsync(string title)
    {
        return await postDao.GetByTitleAsync(title);
    }

    private void ValidateTodo(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Body cannot be empty.");
        if (dto.Body.Length>1800) throw new Exception("Body too long.");
        // other validation stuff
    }
    
    

}