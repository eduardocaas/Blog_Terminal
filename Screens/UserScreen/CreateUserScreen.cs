using Blog.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Screens.UserScreen;

public static class CreateUserScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"
               _____  _____   ______         _______  ______      _    _   _____  ______  _____  
              / ____||  __ \ |  ____|    /\ |__   __||  ____|    | |  | | / ____||  ____||  __ \ 
             | |     | |__) || |__      /  \   | |   | |__       | |  | || (___  | |__   | |__) |
             | |     |  _  / |  __|    / /\ \  | |   |  __|      | |  | | \___ \ |  __|  |  _  / 
             | |____ | | \ \ | |____  / ____ \ | |   | |____     | |__| | ____) || |____ | | \ \ 
              \_____||_|  \_\|______|/_/    \_\|_|   |______|     \____/ |_____/ |______||_|  \_\
       ");
        
        Console.Write("\n >> Name: ");
        string name = Console.ReadLine();
        if (name.IsNullOrEmpty()) Load(connection);
        Console.Write(" >> Email: ");
        string email = Console.ReadLine();
        if (email.IsNullOrEmpty()) Load(connection);
        Console.Write(" >> Password: ");
        string password = Console.ReadLine(); // TODO: gerar hash
        if (password.IsNullOrEmpty()) Load(connection);
        Console.Write(" >> Bio: ");
        string bio = Console.ReadLine();
        if (bio.IsNullOrEmpty()) Load(connection);
        Console.Write(" >> Image: ");
        string image = Console.ReadLine();
        if (image.IsNullOrEmpty()) Load(connection);
        Console.Write(" >> Slug: ");
        string slug = Console.ReadLine();
        if (slug.IsNullOrEmpty()) Load(connection);
        
        Create(connection, new User
        {
            Name = name,
            Email = email,
            PasswordHash = password,
            Bio = bio,
            Image = image,
            Slug = slug
        }); // TODO : gerar hash da senha

    }

    public static void Create(SqlConnection connection, User user)
    {
        //TODO
    }
}