using ConsoleApp12.Models;
using ConsoleApp13;

namespace ConsoleApp12.Services.Users;

internal class UserService
{
    private readonly string path = "C:\\Users\\teacher\\source\\repos\\ConsoleApp13\\User.txt";
    private string Adminemail = "Khule@gmail.com";
    private string AdminPassword = "Paroli123";

    UserMenu um = new UserMenu();
    AdminMenu Am = new AdminMenu();

    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();
        var lines = File.ReadAllLines(path);
        foreach (var item in lines)
        {
            var line = item.Split("|");
            User user = new User(
                int.Parse(line[0]),
                line[1],
                line[1],
                int.Parse(line[0]),
                line[1],
                Enum.Parse<Role>(line[1])
            );
        }

        return users;

    }

    public User? GetUser(int id)
    {
        var user = GetAllUsers().FirstOrDefault(u => u.Id == id);
        return user;
    }

    public void Login(string email, string password)
    {
        var userExists = GetAllUsers().FirstOrDefault(u => u.Email == email
                                                      && u.Password == password
                                                      && u.Role == Role.User);

        var isAdmin = GetAllUsers().FirstOrDefault(u => u.Email == email
                                                      && u.Password == password
                                                      && u.Role == Role.Admin);

        //var isAdmin = GetAllUsers().FirstOrDefault(u => Adminemail == email
        //                                      && AdminPassword == password
        //                                      && u.Role == Role.Admin);

        if (userExists != null) um.MenuRunning();
        else if (isAdmin != null) Am.AdminMenuRunning();
        else Console.WriteLine("user not found");
    }

}
