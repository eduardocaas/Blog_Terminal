using System.Data;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Opw.HttpExceptions;

namespace Blog.Repositories;

public class UserRepository : Repository<User>
{
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection) : base(connection)
        => _connection = connection;

    public List<User> GetWithRoles()
    {
        var query = @"
                    SELECT 
                        [User].*,
                        [Role].*
                    FROM 
                        [User]
                    LEFT JOIN 
                        [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN 
                            [Role] ON [UserRole].[RoleId] = [Role].[Id]
                    ";
        
        var users = new List<User>();

        var items = _connection.Query<User, Role, User>(
            query,
            (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    if (role != null)
                    {
                        usr.Roles.Add(role);
                    }
                    users.Add(usr);
                }
                else
                {
                    usr.Roles.Add(role);
                }

                return user;
            }, splitOn: "Id"
        );
        
        return users;
    }

    private int DeleteUserProcedure(int id)
    {
        string procedure = "[usp_DeleteUser]";
        var pars = new { userId = id };
        return _connection.Execute(
            procedure,
            pars,
            commandType: CommandType.StoredProcedure);
    }
    
    public int DeleteWithProcedure(string email)
    {
        string query = "SELECT [Id] FROM [User] WHERE [User].[Email] = @email";
        IEnumerable<dynamic> user = _connection.Query(query, new { email = email });
        if (user.IsNullOrEmpty())
        {
            throw new NotFoundException("Slug not found!");
        }
        
        dynamic? id = user.FirstOrDefault().Id;
        int rows = 0;
        
        if (id != 0)
        {
            rows = DeleteUserProcedure(id);
        }
        return rows;
    }
    
    public int DeleteWithProcedure(string slug, bool opt)
    {
        string query = "SELECT [Id] FROM [User] WHERE [User].[Slug] = @slug";
        IEnumerable<dynamic> user = _connection.Query(query, new { slug = slug });
        if (user.IsNullOrEmpty())
        {
            throw new NotFoundException("Slug not found!");
        }
        
        dynamic? id = user.FirstOrDefault().Id;
        int rows = 0;
        
        if (id != 0)
        {
            rows = DeleteUserProcedure(id);
        }
        return rows;
    }
    
    public int DeleteWithProcedure(int id)
    {
        int rows = 0;
        //TODO
        if (id != 0)
        {        
            rows = DeleteUserProcedure(id);
        }
        return rows;
    }
}