using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Scrypt;

namespace Blog.Screens.UserScreen;

public static class CreateUserScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        var art = @"
               _____  _____   ______         _______  ______      _    _   _____  ______  _____  
              / ____||  __ \ |  ____|    /\ |__   __||  ____|    | |  | | / ____||  ____||  __ \ 
             | |     | |__) || |__      /  \   | |   | |__       | |  | || (___  | |__   | |__) |
             | |     |  _  / |  __|    / /\ \  | |   |  __|      | |  | | \___ \ |  __|  |  _  / 
             | |____ | | \ \ | |____  / ____ \ | |   | |____     | |__| | ____) || |____ | | \ \ 
              \_____||_|  \_\|______|/_/    \_\|_|   |______|     \____/ |_____/ |______||_|  \_\
       ";
        
        Console.WriteLine(art);

        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write("\n >> Press 'Y' to continue to user creation or 'N' to return to user menu: ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.N) MenuUserScreen.Load(connection);
            if (key == ConsoleKey.Y) Data(connection);
        } while (key != ConsoleKey.Y && key != ConsoleKey.N);
    }

    public static void Data(SqlConnection connection)
    {
        
        Console.Write("\n\n >> Name: ");
        string name = Console.ReadLine();

        Console.Write(" >> Email: ");
        string email = Console.ReadLine();

        Console.Write(" >> Password: ");
        string password = Console.ReadLine();

        Console.Write(" >> Bio: ");
        string bio = Console.ReadLine();

        Console.Write(" >> Image: ");
        string image = Console.ReadLine();

        Console.Write(" >> Slug: ");
        string slug = Console.ReadLine();
        
        if (name.IsNullOrEmpty() || email.IsNullOrEmpty() || password.IsNullOrEmpty() ||
            bio.IsNullOrEmpty() || image.IsNullOrEmpty() || slug.IsNullOrEmpty())
        {
            Console.Write("\n|    Some field was empty or null    | \n\n >> Press key to return to user creation: ");
            Console.ReadKey();
            Load(connection);
        }
        else
        {
            ScryptEncoder encoder = new ScryptEncoder();
            string hashedPassword = encoder.Encode(password);
        
            Create(connection, new User
            {
                Name = name,
                Email = email,
                PasswordHash = hashedPassword,
                Bio = bio,
                Image = image,
                Slug = slug
            });
        }
    }

    public static void Create(SqlConnection connection, User user)
    {
        try
        {
            Repository<User> repository = new Repository<User>(connection);
            repository.Create(user);
            Console.Write("\n|    User created with success!   | \n\n >> Press key to return to user menu: ");
            Console.ReadKey();
            MenuUserScreen.Load(connection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error! {e.Message}");
            Console.WriteLine(" >> Press key to return to user creation: ");
            Console.ReadKey();
            Load(connection);
        }
    }
}