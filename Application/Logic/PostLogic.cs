using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared;
using Shared.DTOs;

namespace Application.Logic;

public class PostLogic:IPostLogic
{
    private readonly IUserDao UserDao;
    private readonly IPostDao PostDao;

    public PostLogic(IUserDao userDao, IPostDao postDao)
    {
        UserDao = userDao;
        PostDao = postDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await UserDao.GetByUsernameAsync(dto.OwnerUsername);
        if (user == null)
        {
            throw new Exception($"User with {dto.OwnerUsername} was not found");
        }

        ValidateTodo(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await PostDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<PostTitleDto>> GetAsync()
    {
        return PostDao.GetAsync();
    }

    private void ValidateTodo(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Body cannot be empty.");
        if (dto.Body.Length>1800) throw new Exception("Body too long.");
        // other validation stuff
    }
    
    

}