using Microsoft.Data.SqlClient;

namespace Blog.Screens.RoleScreen;

public static class MenuRoleScreen
{
    public static void Load(SqlConnection connection)
    {
        Console.Clear();
        Console.WriteLine(@"
              _____   ____  _      ______  _____ 
             |  __ \ / __ \| |    |  ____|/ ____|
             | |__) | |  | | |    | |__  | (___  
             |  _  /| |  | | |    |  __|  \___ \ 
             | | \ \| |__| | |____| |____ ____) |
             |_|  \_\\____/|______|______|_____/                                                                 
        ");

        Console.Write(" >> 1: Show roles \n >> 2: Add role to user \n " + 
                      ">> 3: Numbers of users per role \n >> 4: Delete role \n >> 5: Return \n >> ");

        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1: ListRoleScreen.Load(connection); break;
            case 2: Load(connection); break;
            case 3: Load(connection); break;
            case 4: Load(connection); break;
            case 5: MenuScreen.Load(connection); break;
            default: Load(connection); break;
        }
    }
}