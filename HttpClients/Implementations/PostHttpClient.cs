using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared;
using Shared.DTOs;

namespace HttpClients.Implementations;

public class PostHttpClient: IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<PostTitleDto>> GetAsync()
    {
        HttpResponseMessage response=await client.GetAsync("/Post");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<PostTitleDto> posts = JsonSerializer.Deserialize<ICollection<PostTitleDto>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return posts;

    }

    public async Task<Post> GetByTitleAsync(string title)
    {
        HttpResponseMessage response = await client.GetAsync($"Post/{title}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content); 
        }

        Post post = JsonSerializer.Deserialize<Post>(content, 
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        )!;
        return post; 
    }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}

