namespace Shared;

public class User
{
    public int Id { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }
    public int Age { get; set; }

    public User(String userName, String password,int age)
    {
        UserName = userName;
        Password = password;
        Age = age;
    }
}