using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen;

public class MenuUserScreen
{
    
    
    public static void Load(SqlConnection connection)
    {
        var art = @"
              _    _   _____  ______  _____    _____ 
             | |  | | / ____||  ____||  __ \  / ____|
             | |  | || (___  | |__   | |__) || (___  
             | |  | | \___ \ |  __|  |  _  /  \___ \ 
             | |__| | ____) || |____ | | \ \  ____) |
              \____/ |_____/ |______||_|  \_\|_____/                                               
        ";
        
        ConsoleKey key;
        
        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write(" >> 1: Show users \n >> 2: Show users with roles \n >> 3: Create user" +
                          "\n >> 4: Update user \n >> 5: Delete user \n >> 6: Return \n >> ");
            key = Console.ReadKey().Key;
            
            switch (key)
            {
                case ConsoleKey.D1: ListUserScreen.Load(1, connection); break;
                case ConsoleKey.D2: ListUserScreen.Load(2, connection); break;
                case ConsoleKey.D3: CreateUserScreen.Load(connection); break;
                case ConsoleKey.D4: Load(connection); break;
                case ConsoleKey.D5: DeleteUserScreen.Load(connection); break;
                case ConsoleKey.D6: MenuScreen.Load(connection); break;
                default: continue;
            }
        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 &&
                 key != ConsoleKey.D4 && key != ConsoleKey.D5 && key != ConsoleKey.D6);
    }
}