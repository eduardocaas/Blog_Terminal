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
            Console.WriteLine(art);
            Console.Write("\n >> For user, press 'E' to use Email or 'I' to use Id, 'R' to return to role menu: ");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.R) MenuRoleScreen.Load(connection);
            if (key == ConsoleKey.E) continue;
            if (key == ConsoleKey.I) continue;

        } while (key != ConsoleKey.E && key != ConsoleKey.I && key != ConsoleKey.R);
    }
    
    public static void 
}