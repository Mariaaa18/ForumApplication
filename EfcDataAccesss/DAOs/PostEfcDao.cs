using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;

namespace EfcDataAccesss.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly ForumContext context;
    public PostEfcDao(ForumContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<PostTitleDto>> GetTitlesAsync()
    {
        IQueryable<Post> query = context.Posts.AsQueryable();
        

        List<Post> result = await query.ToListAsync();
        List<PostTitleDto> resultTitles = new List<PostTitleDto>();
        
        for (int i = 0; i < result.Count; i++)
        {
            resultTitles.Add(new PostTitleDto(result[i].Title));
        }
        return resultTitles;
    
    }

    public async Task<Post?> GetByTitleAsync(string title)
    {
       Post? existing= context.Posts.Include(post => post.Owner).FirstOrDefault(p=>p.Title.Equals(title));
       return existing;
    }

    public async Task DeleteAsync(int id)
    {
        Post? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"User with  id{id} not found");
        }

        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? existing= await context.Posts.FindAsync(id);
        return existing;
    }
}