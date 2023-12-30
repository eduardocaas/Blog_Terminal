using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen;

public static class ListUserScreen
{
    public static void Load(short opt, SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"
              _    _  _____ ______ _____       _      _____  _____ _______ 
             | |  | |/ ____|  ____|  __ \     | |    |_   _|/ ____|__   __|
             | |  | | (___ | |__  | |__) |    | |      | | | (___    | |   
             | |  | |\___ \|  __| |  _  /     | |      | |  \___ \   | |   
             | |__| |____) | |____| | \ \     | |____ _| |_ ____) |  | |   
              \____/|_____/|______|_|  \_\    |______|_____|_____/   |_|                                                                                                                            
        ");
        
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