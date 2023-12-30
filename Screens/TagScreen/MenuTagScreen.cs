namespace Blog.Screens.TagScreen;

public static class MenuTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("-------- MENU TAG --------");
        Console.Write(" >> 1: Show tags \n >> 2: Create tag \n >> 3: Update tag \n >> 4: Delete tag \n >> ");
        short option = short.Parse(Console.ReadLine());
        
        switch (option)
        {
            case 1: Load(); break;
            case 2: Load(); break;
            case 3: Load(); break;
            case 4: Load(); break;
            default: Load(); break;
        }
    }
}