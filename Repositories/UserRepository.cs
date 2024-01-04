using System.Data;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

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

    public int DeleteByEmail(string email)
    {
        string query = "SELECT [Id] FROM [User] WHERE [User].[Email] = @email";
        IEnumerable<dynamic> user = _connection.Query(query, new { email = email });
        dynamic? id = user.FirstOrDefault().Id;
        int rows = 0;
        
        if (id != 0)
        {        
            string procedure = "[sp_DeleteUser]";
            var pars = new { userId = id };
            rows = _connection.Execute(
                procedure,
                pars,
                commandType: CommandType.StoredProcedure);
        }
        return rows;
    }
}