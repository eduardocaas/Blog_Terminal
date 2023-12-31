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
            Console.Write("Press 'I' to delete user by Id or 'N' to delete user by Name or 'R' to return: ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.R) MenuUserScreen.Load(connection); break;
            
        } while (key != ConsoleKey.I && key != ConsoleKey.N && key != ConsoleKey.R);
        
        
    }
}