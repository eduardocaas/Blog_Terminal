using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreen;

public static class MenuTagScreen
{
    public static void Load(SqlConnection connection)
    {
        var art = @"
              _______         _____   _____ 
             |__   __| /\    / ____| / ____|
                | |   /  \  | |  __ | (___  
                | |  / /\ \ | | |_ | \___ \ 
                | | / ____ \| |__| | ____) |
                |_|/_/    \_\\_____||_____/                      
        ";

        ConsoleKey key;
        
        do
        {
            Console.Clear();
            Console.WriteLine(art);
            Console.Write(" >> 1: Show tags \n >> 2: Create tag \n >> 3: Add tag to post \n >> 4: Return \n >> ");
            key = Console.ReadKey().Key;
                    
            switch (key)
            {
                case ConsoleKey.D1: ListTagScreen.Load(connection); break;
                case ConsoleKey.D2: CreateTagScreen.Load(connection); break;
                case ConsoleKey.D3: Load(connection); break;
                case ConsoleKey.D4: MenuScreen.Load(connection); break;
                default: continue;
            }
        } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && key != ConsoleKey.D4);
    }
}