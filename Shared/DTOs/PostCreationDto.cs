namespace Shared.DTOs;

public class PostCreationDto
{
    public int? IdOwner { get; }
    
    public string Owner { get; }
    public string Title { get; }
    public string Body { get; }

    public PostCreationDto(string owner, string title, string body)
    {
        Owner = owner;
        Title = title;
        Body = body;
    }
}