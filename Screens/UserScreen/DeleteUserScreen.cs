using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Opw.HttpExceptions;

namespace Blog.Screens.UserScreen;

public static class DeleteUserScreen
{
    public static void Load(SqlConnection connection)
    {

        var art = @"
              _____   ______  _       ______  _______  ______      _    _   _____  ______  _____  
             |  __ \ |  ____|| |     |  ____||__   __||  ____|    | |  | | / ____||  ____||  __ \ 
             | |  | || |__   | |     | |__      | |   | |__       | |  | || (___  | |__   | |__) |
             | |  | ||  __|  | |     |  __|     | |   |  __|      | |  | | \___ \ |  __|  |  _  / 
             | |__| || |____ | |____ | |____    | |   | |____     | |__| | ____) || |____ | | \ \ 
             |_____/ |______||______||______|   |_|   |______|     \____/ |_____/ |______||_|  \_\
        ";
        
        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write("\n >> Press 'I' to delete user by Id, 'E' to delete user by Email, 'S' to delete user by Slug or 'R' to return: ");
            // TODO - adicionar opcao slug
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.R) { MenuUserScreen.Load(connection); break; }
            if (key == ConsoleKey.I) Delete(connection, 1);
            if (key == ConsoleKey.E) Delete(connection, 2);
            if (key == ConsoleKey.S) Delete(connection, 3);
            
        } while (key != ConsoleKey.I && key != ConsoleKey.E && key != ConsoleKey.S && key != ConsoleKey.R);
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

                if (row == 0) // TODO - Throwing exception in REPOSITORY 
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
            }
            else if (option == 3)
            {
                Console.Write("\n\n >> Slug: ");
                string slug = Console.ReadLine();
                row = repository.DeleteWithProcedure(slug, true);
            }

            if (row == 1)
            {
                Console.Write("\n |      User deleted with success!      | \n\n >> Press key to return to user menu: ");
                Console.ReadKey();
                MenuUserScreen.Load(connection);
            }
            else if (row >= 2)
            {
                Console.Write(
                    "\n |      User and roles relation deleted with success!      | \n\n >> Press key to return to user menu: ");
                Console.ReadKey();
                MenuUserScreen.Load(connection);
            }

        }
        catch (NotFoundException ex)
        {
            Console.WriteLine($"\nError code: {ex.StatusCode.GetHashCode()} - message: {ex.Message}");
            Console.Write("\n >> Press key to return to user delete: ");
            Console.ReadKey();
            Load(connection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nError code: 500 - message: {e.Message}");
            Console.Write("\n >> Press key to return to user delete: ");
            Console.ReadKey();
            Load(connection);
        }
    }
}