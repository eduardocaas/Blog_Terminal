using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.RoleScreen;

public static class ListRoleScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"
              _____   ____  _      ______  _____      _      _____  _____ _______ 
             |  __ \ / __ \| |    |  ____|/ ____|    | |    |_   _|/ ____|__   __|
             | |__) | |  | | |    | |__  | (___      | |      | | | (___    | |   
             |  _  /| |  | | |    |  __|  \___ \     | |      | |  \___ \   | |   
             | | \ \| |__| | |____| |____ ____) |    | |____ _| |_ ____) |  | |   
             |_|  \_\\____/|______|______|_____/     |______|_____|_____/   |_|                                                                      
        ");
        Read(connection);
        Console.Write("\n\n >> Press key to return to role menu: ");
        Console.ReadKey();
        MenuRoleScreen.Load(connection);
    }

    public static void Read(SqlConnection connection)
    {
        Repository<Role> repository = new Repository<Role>(connection);
        IEnumerable<Role> items = repository.Get();

        foreach (Role item in items)
        {
            Console.WriteLine($"{item.Id} - {item.Name}");
        }
    }
}