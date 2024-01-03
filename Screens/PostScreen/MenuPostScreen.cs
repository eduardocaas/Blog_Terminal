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
            Console.Write(" >> 1: Show post by");
        } while (expression);
    }
}