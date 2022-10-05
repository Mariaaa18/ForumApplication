using Application.DaoInterfaces;
using Shared;
using Shared.DTOs;

namespace FileData.DAOs;

public class PostFileDao :IPostDao
{
    private readonly FileContext context;
    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(u => u.Id);
            id++;
        }

        post.Id = id;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public async Task<IEnumerable<PostTitleDto>> GetTitlesAsync()
    {
        List<Post> result = context.Posts.AsEnumerable().ToList();
        List<PostTitleDto> resultTitle = new List<PostTitleDto>();
        for (int i = 0; i < result.Count; i++)
        {
            resultTitle.Add(new PostTitleDto(result[i].Title));
        }

        return resultTitle.AsEnumerable();
    }

    public Task<Post?> GetByTitleAsync(string title)
    {
        Post? existing = context.Posts.FirstOrDefault(t => t.Title ==title );
        return Task.FromResult(existing);
    }
}