using System.Data;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
        => _connection = connection;

    public int DeleteRoleProcedure(int id)
    {
        string procedure = "[usp_DeleteRole]";
        var pars = new { roleId = id };
        return _connection.Execute(
            procedure,
            pars,
            commandType: CommandType.StoredProcedure
        );
    }
    
    public int DeleteWithProcedure(int id)
    {
        Role role = _connection.Get<Role>(id);

        int rows = 0;
        if (role.Id != 0)
            rows = DeleteRoleProcedure(id);
        
        return rows;
    }

    public int DeleteWithProcedure(string Slug)
    {
        string query = "SELECT [Id] FROM [Role] WHERE [Role].[Slug] = @slug";
        IEnumerable<dynamic> role = _connection.Query(query, new { slug = Slug });
        dynamic? id = role.FirstOrDefault().Id;
        
        int rows = 0;
        if (id != 0)
            rows = DeleteRoleProcedure(id);
        
        return rows;
    }
}