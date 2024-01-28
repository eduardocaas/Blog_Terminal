using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Opw.HttpExceptions;

namespace Blog.Repositories;

public class UserRoleRepository
{
    private readonly SqlConnection _connection;

    public UserRoleRepository(SqlConnection connection)
        => _connection = connection;
    
    public void InsertUserRole(string userEmail, string roleSlug)
    {
        UserRepository userRepository = new UserRepository(_connection);
        RoleRepository roleRepository = new RoleRepository(_connection);

        int userId = userRepository.GetIdByEmail(userEmail);
        if (userId == 0)
            throw new NotFoundException($"User with email: {userEmail} not found!");

        var roleId = roleRepository.GetIdBySlug(roleSlug);
        if (roleId == 0)
            throw new NotFoundException($"Role with slug: {roleSlug} not found!");
        
        var query = "INSERT INTO [UserRole] VALUES(@userId, @roleId)";
        
        _connection.Execute(query, new { userId = userId, roleId = roleId });
    }

    public int InsertUserRole(int userId, string roleSlug)
    {
        // TODO: Chamar user repository , fazer select 1, se retornar, reutilizar ID
        // TODO: Chamar role repository ,fazer select id
        // TODO: realizar insert com id's na userrole
        return 0;
    }
}