using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Opw.HttpExceptions;

namespace Blog.Screens.RoleScreen;

public class DeleteRoleScreen
{

    public static void Load(SqlConnection connection)
    {
        var art = @"
              _____   ______  _       ______  _______  ______      _____    ____   _       ______  
             |  __ \ |  ____|| |     |  ____||__   __||  ____|    |  __ \  / __ \ | |     |  ____| 
             | |  | || |__   | |     | |__      | |   | |__       | |__) || |  | || |     | |__    
             | |  | ||  __|  | |     |  __|     | |   |  __|      |  _  / | |  | || |     |  __|   
             | |__| || |____ | |____ | |____    | |   | |____     | | \ \ | |__| || |____ | |____  
             |_____/ |______||______||______|   |_|   |______|    |_|  \_\ \____/ |______||______|                                                                        
        ";

        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write("\n >> Press 'I' to delete Role by Id or 'S' to delete Role by Slug or 'R' to return: ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.R) { MenuRoleScreen.Load(connection); break; }
            if (key == ConsoleKey.I) Delete(connection, 1);
            if (key == ConsoleKey.S) Delete(connection, 2);

        } while (key != ConsoleKey.I && key != ConsoleKey.S && key != ConsoleKey.R);
    }

    public static void Delete(SqlConnection connection, short option)
    {
        RoleRepository repository = new RoleRepository(connection);

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
                   Console.Write("\n |    Id not found!    | \n\n >> Press key to return to delete role: ");
                   Console.ReadKey();
                   Load(connection);
               }
            }
            else if (option == 2)
            {
                Console.Write("\n\n >> Slug: ");
                string slug = Console.ReadLine();
                row = repository.DeleteWithProcedure(slug);
            }

            if (row == 1)
            {
                Console.Write("\n |      Role deleted with success!      | \n\n >> Press key to return to role menu: ");
                Console.ReadKey();
                MenuRoleScreen.Load(connection);
            }
            else if (row >= 2)
            {
                Console.Write("\n |      Role and users relation deleted with success!      | \n\n >> Press key to return to role menu: ");
                Console.ReadKey();
                MenuRoleScreen.Load(connection);
            }
        }
        catch (NotFoundException ex)
        {
            Console.WriteLine($"\nError code: {ex.StatusCode.GetHashCode()} - message: {ex.Message}");
            Console.Write("\n >> Press key to return to role delete: ");
            Console.ReadKey();
            Load(connection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nError! {e.Message}");
            Console.WriteLine(" >> Press key to return to role delete: ");
            Console.ReadKey();
            Load(connection);
        }
    }
}