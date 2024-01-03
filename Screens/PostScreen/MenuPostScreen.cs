using Microsoft.Data.SqlClient;

namespace Blog.Screens.PostScreen;

public class MenuPostScreen
{
    public static void Load(SqlConnection connection)
    {
        var art = @"
              _____    ____    _____  _______  _____ 
             |  __ \  / __ \  / ____||__   __|/ ____|
             | |__) || |  | || (___     | |  | (___  
             |  ___/ | |  | | \___ \    | |   \___ \ 
             | |     | |__| | ____) |   | |   ____) |
             |_|      \____/ |_____/    |_|  |_____/                     
        ";

        ConsoleKey key;
        
        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write(" >> 1: Show post by slug \n >> 2: Show posts by author slug \n >> 3: " +
                          "Create post \n >> 4: Update post \n >> 5: Delete post \n >> 6: Return \n >> ");
            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1: Load(connection); break;
                case ConsoleKey.D2: Load(connection); break;
                case ConsoleKey.D3: Load(connection); break;
                case ConsoleKey.D4: Load(connection); break;
                case ConsoleKey.D5: Load(connection); break;
                case ConsoleKey.D6: MenuScreen.Load(connection); break;
                default: continue;
            }
            
        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && 
                 key != ConsoleKey.D4 && key != ConsoleKey.D5 && key != ConsoleKey.D6);
    }
}