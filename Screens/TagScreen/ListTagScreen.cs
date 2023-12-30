using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreen;

public static class ListTagScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"    
              _______         _____      _       _____   _____  _______ 
             |__   __| /\    / ____|    | |     |_   _| / ____||__   __|
                | |   /  \  | |  __     | |       | |  | (___     | |   
                | |  / /\ \ | | |_ |    | |       | |   \___ \    | |   
                | | / ____ \| |__| |    | |____  _| |_  ____) |   | |   
                |_|/_/    \_\\_____|    |______||_____||_____/    |_|            
        ");
        Read(connection);
        Console.Write("\n\n >> Press key to return to tag menu: ");
        Console.ReadKey();
        MenuTagScreen.Load(connection);
    }

    public static void Read(SqlConnection connection)
    {
        Repository<Tag> repository = new Repository<Tag>(connection);
        IEnumerable<Tag> items = repository.Get();

        foreach (Tag item in items)
            Console.WriteLine($"{item.Id} - {item.Name}");
    }
}