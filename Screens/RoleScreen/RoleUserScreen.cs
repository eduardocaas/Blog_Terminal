using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.RoleScreen;

public static class RoleUserScreen
{
    public static void Load(SqlConnection connection)
    {
        var art = @"
              _____    ____   _       ______      _    _   _____  ______  _____  
             |  __ \  / __ \ | |     |  ____|    | |  | | / ____||  ____||  __ \ 
             | |__) || |  | || |     | |__       | |  | || (___  | |__   | |__) |
             |  _  / | |  | || |     |  __|      | |  | | \___ \ |  __|  |  _  / 
             | | \ \ | |__| || |____ | |____     | |__| | ____) || |____ | | \ \ 
             |_|  \_\ \____/ |______||______|     \____/ |_____/ |______||_|  \_\                                                           
        ";

        ConsoleKey key;

        do 
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write("\n >> For user, press 'E' to use Email or 'I' to use Id, 'R' to return to role menu: ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.R) MenuRoleScreen.Load(connection);
            if (key == ConsoleKey.E) Insert(connection, 1);
            if (key == ConsoleKey.I) Insert(connection, 2);

        } while (key != ConsoleKey.E && key != ConsoleKey.I && key != ConsoleKey.R);
    }

    private static void Insert(SqlConnection connection, short opt)
    {

        UserRoleRepository repository = new UserRoleRepository(connection);
        
        if (opt == 1)
        {
            Console.Write("\n\n >> User Email: ");
            string userEmail = Console.ReadLine();
            Console.Write(" >> Role Slug: ");
            string roleSlug = Console.ReadLine();
            
            try
            {
                repository.InsertUserRole(userEmail, roleSlug);
                Console.Write("\n|    Role add to user with success!    | \n\n >> Press key to return role menu: ");
                Console.ReadKey();
                MenuRoleScreen.Load(connection);
            }
            catch (Exception e)
            {
                if (e.HResult == -2146232060)
                {
                    Console.WriteLine($"\n <<<< ERROR >>>> \n Message: Register already exists!");
                    Console.WriteLine("\n >> Press key to return to role user menu: ");
                    Console.ReadKey();
                    Load(connection);
                }
                else
                {
                    Console.WriteLine("\n <<<< ERROR >>>> \n Message: {e.Message} {e.HResult}");
                    Console.WriteLine("\n >> Press key to return to role user menu: ");
                    Console.ReadKey();
                    Load(connection);
                }
            }
        }
        if (opt == 2)
        {
            Console.WriteLine("\n\n >> User Id: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write(" >> Role Slug: ");
            string roleSlug = Console.ReadLine();

            try
            {
                repository.InsertUserRole(userId, roleSlug);
                Console.Write("\n|    Role add to user with success!    | \n\n > Press key to return to role menu: ");
                Console.ReadKey();
                MenuRoleScreen.Load(connection);
            }
            catch (Exception e)
            {
                if (e.HResult == -2146232060)
                {
                    Console.WriteLine("\n <<<< ERROR >>>> \n Message: Register already exists!");
                    Console.WriteLine("\n >> Press key to return to role user menu: ");
                    Console.ReadKey();
                    Load(connection);
                }
                else
                {
                    Console.WriteLine($"\n <<<< ERROR >>>> \n Message: {e.Message}");
                    Console.WriteLine("\n >> Press key to return to role user menu: ");
                    Console.ReadKey();
                    Load(connection);
                }
            }
        }
    }
}