using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRoleRepository
{
    private readonly SqlConnection _connection;

    public UserRoleRepository(SqlConnection connection)
        => _connection = connection;

    public int InsertUserRole(string userEmail, string roleSlug)
    {
        // TODO: Chamar user repository , fazer select id,
        // TODO: Chamar role repository ,fazer select id
        // TODO: realizar insert com id's na userrole
        return 0;
    }

    public int InsertUserRole(int userId, string roleSlug)
    {
        // TODO: Chamar user repository , fazer select 1, se retornar, reutilizar ID
        // TODO: Chamar role repository ,fazer select id
        // TODO: realizar insert com id's na userrole
        return 0;
    }
}