using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen;

public static class DeleteUserScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        var art = @"
              _____   ______  _       ______  _______  ______      _    _   _____  ______  _____  
             |  __ \ |  ____|| |     |  ____||__   __||  ____|    | |  | | / ____||  ____||  __ \ 
             | |  | || |__   | |     | |__      | |   | |__       | |  | || (___  | |__   | |__) |
             | |  | ||  __|  | |     |  __|     | |   |  __|      | |  | | \___ \ |  __|  |  _  / 
             | |__| || |____ | |____ | |____    | |   | |____     | |__| | ____) || |____ | | \ \ 
             |_____/ |______||______||______|   |_|   |______|     \____/ |_____/ |______||_|  \_\
        ";
        Console.WriteLine(art);
        ConsoleKey key;
        do
        {
            Console.Write("\n >> Press 'I' to delete user by Id or 'E' to delete user by Email or 'R' to return: ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.R) { MenuUserScreen.Load(connection); break; }
            if (key == ConsoleKey.I) Delete(connection, 1);
            if (key == ConsoleKey.E) Delete(connection, 2);
            
        } while (key != ConsoleKey.I && key != ConsoleKey.E && key != ConsoleKey.R);
    }

    public static void Delete(SqlConnection connection, short option)
    {
        UserRepository repository = new UserRepository(connection);

        try
        {
            int row = 0;
            
            if (option == 1)
            {
                Console.Write("\n\n >> Id: ");
                int id = int.Parse(Console.ReadLine());

                row = repository.DeleteWithProcedure(id);

                if (row == 0)
                {
                    Console.Write("\n |    Id not found!    | \n\n >> Press key to return to delete user: ");
                    Console.ReadKey();
                    Load(connection);
                }
            }
            else if (option == 2)
            {
                Console.Write("\n\n >> Email: ");
                string email = Console.ReadLine();
                row = repository.DeleteWithProcedure(email);
                if (row == 0)
                {
                    Console.Write("\n |    Email not found!    | \n\n >> Press key to return to delete user: ");
                    Console.ReadKey();
                    Load(connection);
                }
            }
            
            if (row == 1)
            {
                Console.Write("\n |      User deleted with success!      | \n\n >> Press key to return to user menu: ");
                Console.ReadKey();
                MenuUserScreen.Load(connection);
            }
            else if (row >= 2)
            {
                Console.Write("\n |      User and roles relation deleted with success!      | \n\n >> Press key to return to user menu: ");
                Console.ReadKey();
                MenuUserScreen.Load(connection);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error! {e.Message}");
            Console.WriteLine(" >> Press key to return to user delete: ");
            Console.ReadKey();
            Load(connection);
        }
    }
}