namespace Application.DaoInterfaces;

public class UserCreationDto
{
    public String UserName { get; }
    public String  Password { get; }

    public UserCreationDto(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}