namespace Shared;

public class User
{
    public int Id { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }

    public User(String userName, String password)
    {
        UserName = userName;
        Password = password;
    }
}