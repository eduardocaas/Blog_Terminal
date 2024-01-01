using Blog.Screens.RoleScreen;
using Blog.Screens.TagScreen;
using Blog.Screens.UserScreen;
using Microsoft.Data.SqlClient;

namespace Blog.Screens;

public static class MenuScreen
{
    public static void Load(SqlConnection connection)
    {
        var art =@"         
              __  __  ______  _   _  _    _ 
             |  \/  ||  ____|| \ | || |  | |
             | \  / || |__   |  \| || |  | |
             | |\/| ||  __|  | . ` || |  | |
             | |  | || |____ | |\  || |__| |
             |_|  |_||______||_| \_| \____/                                                                                
        ";
        
        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write(" >> 1: Users \n >> 2: Posts \n >> 3: Roles \n >>" +
                          " 4: Tags \n >> 5: Categories \n >> 6: Exit \n >> ");
            key = Console.ReadKey().Key;
            
            switch (key)
            {
                case ConsoleKey.D1: MenuUserScreen.Load(connection); break;
                case ConsoleKey.D2: Load(connection); break;
                case ConsoleKey.D3: MenuRoleScreen.Load(connection); break;
                case ConsoleKey.D4: MenuTagScreen.Load(connection); break;
                case ConsoleKey.D5: Load(connection); break;
                case ConsoleKey.D6: Console.Clear(); break;
                default: continue;
            }
            
        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 &&
                 key != ConsoleKey.D4 && key != ConsoleKey.D5 && key != ConsoleKey.D6);
    }
}