using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
        => _connection = connection;

    public int DeleteWithProcedure(int id)
    {
        return 0;
    }

    public int DeleteWithProcedure(string Slug)
    {
        string query = "SELECT [Id] FROM [Role] WHERE [Role].[Slug] = @slug";
        IEnumerable<dynamic> role = _connection.Query(query, new { slug = Slug });
        dynamic? id = role.FirstOrDefault().Id;
        
        int rows = 0;
        if (id != 0)
        {
            string procedure = "[usp_DeleteRole]";
            var pars = new { roleId = id };
            rows = _connection.Execute(
                procedure,
                pars,
                commandType: CommandType.StoredProcedure
            );
        }
        return rows;
    }
}