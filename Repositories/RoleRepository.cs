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
        
    }
}