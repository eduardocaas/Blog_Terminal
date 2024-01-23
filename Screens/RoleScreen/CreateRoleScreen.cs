using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Screens.RoleScreen;

public class CreateRoleScreen
{
    public static void Load(SqlConnection connection)
    {
        var art = @"";
        
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write("\n >> Press 'Y' to continue to Role creation or 'R' to return to Role menu: ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.R) { MenuRoleScreen.Load(connection); }
            if (key == ConsoleKey.Y) { Data(connection); }
        } while (key != ConsoleKey.Y && key != ConsoleKey.R);
    }

    public static void Data(SqlConnection connection)
    {
        Console.Write("\n\n >> Name: ");
        string name = Console.ReadLine();
        
        Console.Write("\n >> Slug: ");
        string slug = Console.ReadLine();

        if (name.IsNullOrEmpty() || slug.IsNullOrEmpty())
        {
            Console.Write("\n|    Some field was empty or null    | \n\n >> Press key to return to role creation: ");
            Console.ReadKey();
            Load(connection);
        }
        else
        {
            Role role = new Role();
            role.Name = name;
            role.Slug = slug;
            Create(connection, role);
        }
    }

    public static void Create(SqlConnection connection, Role role)
    {
        try
        {
            Repository<Role> repository = new Repository<Role>(connection);
            repository.Create(role);
            Console.Write("\n|    Role created with success!   | \n\n >> Press key to return to role menu: ");
            Console.ReadKey();
            MenuRoleScreen.Load(connection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error! {e.Message}");
            Console.WriteLine(" >> Press key to return to role creation: ");
            Console.ReadKey();
            Load(connection);
        }
    }
}