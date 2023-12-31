using Microsoft.Data.SqlClient;

namespace Blog.Screens.UserScreen;

public class MenuUserScreen
{
    
    
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"
              _    _   _____  ______  _____    _____ 
             | |  | | / ____||  ____||  __ \  / ____|
             | |  | || (___  | |__   | |__) || (___  
             | |  | | \___ \ |  __|  |  _  /  \___ \ 
             | |__| | ____) || |____ | | \ \  ____) |
              \____/ |_____/ |______||_|  \_\|_____/                                               
        ");
        Console.Write(" >> 1: Show users \n >> 2: Show users with roles \n >> 3: Create user" +
                        "\n >> 4: Update user \n >> 5: Delete user \n >> 6: Return \n >> ");
        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1: ListUserScreen.Load(1, connection); break;
            case 2: ListUserScreen.Load(2, connection); break;
            case 3: CreateUserScreen.Load(connection); break;
            case 4: Load(connection); break;
            case 5: Load(connection); break;
            case 6: MenuScreen.Load(connection); break;
            default: Load(connection); break;
        }
    }
}