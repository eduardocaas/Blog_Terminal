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
        if (name.IsNullOrEmpty()) Load(connection);
        Console.Write("\n >> Slug: ");
        string slug = Console.ReadLine();
        
        Create(connection, name, slug);
    }

    public static void Create(SqlConnection connection, string name, string slug)
    {
        
    }
}