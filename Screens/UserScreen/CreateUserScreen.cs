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
        Console.WriteLine(@"
               _____  _____   ______         _______  ______      _    _   _____  ______  _____  
              / ____||  __ \ |  ____|    /\ |__   __||  ____|    | |  | | / ____||  ____||  __ \ 
             | |     | |__) || |__      /  \   | |   | |__       | |  | || (___  | |__   | |__) |
             | |     |  _  / |  __|    / /\ \  | |   |  __|      | |  | | \___ \ |  __|  |  _  / 
             | |____ | | \ \ | |____  / ____ \ | |   | |____     | |__| | ____) || |____ | | \ \ 
              \_____||_|  \_\|______|/_/    \_\|_|   |______|     \____/ |_____/ |______||_|  \_\
       ");
        
        Console.Write("\n >> Name: ");  //TODO : refatorar codigo: colocar condicao nula apos chamada de todos metodos
        string name = Console.ReadLine();
        if (name.IsNullOrEmpty()) Load(connection);
        Console.Write(" >> Email: ");
        string email = Console.ReadLine();
        if (email.IsNullOrEmpty()) Load(connection);
        Console.Write(" >> Password: ");
        string password = Console.ReadLine();
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