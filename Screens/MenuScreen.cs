using Blog.Screens.RoleScreen;
using Blog.Screens.TagScreen;
using Blog.Screens.UserScreen;
using Microsoft.Data.SqlClient;

namespace Blog.Screens;

public static class MenuScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"         
              __  __  ______  _   _  _    _ 
             |  \/  ||  ____|| \ | || |  | |
             | \  / || |__   |  \| || |  | |
             | |\/| ||  __|  | . ` || |  | |
             | |  | || |____ | |\  || |__| |
             |_|  |_||______||_| \_| \____/                                                                                
        ");
        Console.Write(" >> 1: Users \n >> 2: Posts \n >> 3: Roles \n >> 4: Tags \n >> 5: Categories \n >> 6: Exit \n >> ");
        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1: MenuUserScreen.Load(connection); break;
            case 2: Load(connection); break;
            case 3: MenuRoleScreen.Load(connection); break;
            case 4: MenuTagScreen.Load(connection); break;
            case 5: Load(connection); break;
            case 6: Console.Clear(); break;
            default: Load(connection); break;
        }
    }
}