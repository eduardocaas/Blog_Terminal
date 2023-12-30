using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Screens.TagScreen;

public static class CreateTagScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"
               _____  _____   ______         _______  ______      _______         _____ 
              / ____||  __ \ |  ____|    /\ |__   __||  ____|    |__   __| /\    / ____|
             | |     | |__) || |__      /  \   | |   | |__          | |   /  \  | |  __ 
             | |     |  _  / |  __|    / /\ \  | |   |  __|         | |  / /\ \ | | |_ |
             | |____ | | \ \ | |____  / ____ \ | |   | |____        | | / ____ \| |__| |
              \_____||_|  \_\|______|/_/    \_\|_|   |______|       |_|/_/    \_\\_____|                                                      
        ");
        Console.Write("\n >> Name: ");
        string name = Console.ReadLine();
        if (name.IsNullOrEmpty()) Load(connection); // TODO: loop when call this method
        Console.Write(" >> Slug: ");
        string slug = Console.ReadLine();
        if (slug.IsNullOrEmpty()) Load(connection);
        
        Create(connection, new Tag { Name = name, Slug = slug } );
    }

    public static void Create(SqlConnection connection, Tag tag)
    {
        try
        {
            Repository<Tag> repository = new Repository<Tag>(connection);
            repository.Create(tag);
            Console.Write("\n|    Tag created with success!   | \n\n >> Press key to return to tag menu: ");
            Console.ReadKey();
            MenuTagScreen.Load(connection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error! {e.Message}");
            Console.WriteLine(" >> Press key to return to tag creation: ");
            Console.ReadKey();
            Load(connection);
        }
    }
}