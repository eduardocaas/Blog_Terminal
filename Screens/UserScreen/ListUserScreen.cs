using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen;

public static class ListUserScreen
{
    public static void Load(short opt, SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine("-------- USER LIST --------");
        if (opt == 1)
            Read(connection);
        if (opt == 2)
            ReadWithRoles(connection);
            
        Console.Write("\n\n >> Press key to return to user menu: ");
        Console.ReadKey();
        MenuUserScreen.Load(connection);
    }

    public static void Read(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var items = repository.Get();

        foreach (User item in items)
            Console.WriteLine($"{item.Id} - {item.Name} - {item.Email}");
    }

    public static void ReadWithRoles(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var items = repository.GetWithRoles();

        foreach (User item in items)
        {
            Console.Write($"{item.Id} - {item.Name} - {item.Email}");
            foreach (Role role in item.Roles)
            {
                Console.WriteLine($" - {role.Name}");
            }
        }
    }
}