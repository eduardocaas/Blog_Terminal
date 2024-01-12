using Blog.Models;
using Blog.Repositories;
using Blog.Screens;
using Blog.Screens.TagScreen;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private const string CONNECTION_STRING_LOCAL = @"Server=DESKTOP-34LI74D;
                                            Database=Blog;
                                            Trusted_Connection=True;
                                            TrustServerCertificate=True;";

    private const string CONNECTION_STRING_VM = @"Data Source=192.168.0.16,1433;
                                                Initial Catalog=Blog;
                                                Trusted_Connection=True;
                                                TrustServerCertificate=True;
                                                Integrated Security=False;
                                                Connect Timeout=30;
                                                user ID=sa;password=rhelMS_r00t_Password#";

    static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING_VM);
        connection.Open();
        
        MenuScreen.Load(connection);
        
        //ReadUsers(connection);
        //ReadUserWithRoles(connection);
        //CreateUsers(connection);
        
        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var items = repository.Get();

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id} - {item.Name}");
            foreach (var role in item.Roles)
                Console.WriteLine($"- {role.Name}");
        }
    }
    
    
    public static void ReadUserWithRoles(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var items = repository.GetWithRoles();

        foreach (var item in items)
        {
            Console.Write($"{item.Name}");
            foreach (var role in item.Roles)
            {//todo: criar condicao caso role name seja nula
                Console.WriteLine($" - {role.Name}");
            }
        }
    }

    public static void CreateUsers(SqlConnection connection)
    {
        var user = new User()
        {
            Name = "Beltrano",
            Email = "beltrano@email.com",
            PasswordHash = "HASH",
            Bio = "bio",
            Image = "https://",
            Slug = "beltrano"
        };
        var repository = new Repository<User>(connection);
        repository.Create(user);
    }
    
    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new Repository<Role>(connection);
        var items = repository.Get();

        foreach (var item in items)
            Console.WriteLine($"{item.Id} - {item.Name}");
    }

    public static void ReadTags(SqlConnection connection)
    {
        var tagRepository = new Repository<Tag>(connection);
        var items = tagRepository.Get();

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id} - {item.Name}");
        }
    }
}