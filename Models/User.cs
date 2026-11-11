
namespace ConsoleApp12.Models;

internal class User
{
    public User(int id, string name, string email, int age, string password, Role role)
    {
        Id = id;
        Name = name;
        Email = email;
        Age = age;
        Password = password;
        Role = role;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; } = Role.User;



}
public enum Role
{
    User,
    Admin
}