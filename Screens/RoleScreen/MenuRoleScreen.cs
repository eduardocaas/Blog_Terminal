using Microsoft.Data.SqlClient;

namespace Blog.Screens.RoleScreen;

public static class MenuRoleScreen
{
    public static void Load(SqlConnection connection)
    {
        var art = @"
              _____    ____   _       ______   _____ 
             |  __ \  / __ \ | |     |  ____| / ____|
             | |__) || |  | || |     | |__   | (___  
             |  _  / | |  | || |     |  __|   \___ \ 
             | | \ \ | |__| || |____ | |____  ____) |
             |_|  \_\ \____/ |______||______||_____/                                                      
        ";

        ConsoleKey key;
        
        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write(" >> 1: Show roles \n >> 2: Add role to user \n " + 
                          ">> 3: Numbers of users per role \n >> 4: Delete role \n >> 5: Return \n >> ");
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1: ListRoleScreen.Load(connection); break;
                case ConsoleKey.D2: Load(connection); break;
                case ConsoleKey.D3: Load(connection); break;
                case ConsoleKey.D4: DeleteRoleScreen.Load(connection); break;
                case ConsoleKey.D5: MenuScreen.Load(connection); break;
                default: continue;
            }

        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != 
                 ConsoleKey.D3 && key != ConsoleKey.D4 && key != ConsoleKey.D5);
    }
}