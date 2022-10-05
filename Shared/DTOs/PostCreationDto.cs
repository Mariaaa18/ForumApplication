namespace Shared.DTOs;

public class PostCreationDto
{
    public int IdOwner { get; }
    
    public string? OwnerUsername { get; }
    public string Title { get; }
    public string Body { get; }

    public PostCreationDto(int idOwner, string title, string body)
    {
        IdOwner = idOwner;
        Title = title;
        Body = body;
    }
}