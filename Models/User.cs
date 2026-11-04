
namespace ConsoleApp12.Models;

internal class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public bool IsVerified { get; set; } = false;
    public string? Code { get; set; } = null;
    public User(int id, string name, string email, int age,
        string password, bool isVerified, string? code)
    {
        Id = id;
        Name = name;
        Email = email;
        Age = age;
        Password = password;
        IsVerified = isVerified;
        Code = code;
    }

}
