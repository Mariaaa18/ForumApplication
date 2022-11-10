namespace Shared.DTOs;

public class UserCreationDto
{
    public String UserName { get; }
    public String  Password { get; }
    public int Age { get; set; }

    public UserCreationDto(string userName, string password,int age)
    {
        UserName = userName;
        Password = password;
        Age = age;
    }
}