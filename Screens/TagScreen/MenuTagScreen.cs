using Microsoft.Data.SqlClient;

namespace Blog.Screens.TagScreen;

public static class MenuTagScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"
              _______         _____   _____ 
             |__   __| /\    / ____| / ____|
                | |   /  \  | |  __ | (___  
                | |  / /\ \ | | |_ | \___ \ 
                | | / ____ \| |__| | ____) |
                |_|/_/    \_\\_____||_____/                      
        ");
        Console.Write(" >> 1: Show tags \n >> 2: Create tag \n >> 3: Add tag to post" +
                      " \n >> 4: Delete tag \n >> 5: Return \n >> ");
        
        short option = short.Parse(Console.ReadLine());
        
        switch (option)
        {
            case 1: ListTagScreen.Load(connection); break;
            case 2: Load(connection); break;
            case 3: Load(connection); break;
            case 4: Load(connection); break;
            case 5: MenuScreen.Load(connection); break;
            default: Load(connection); break;
        }
    }
}