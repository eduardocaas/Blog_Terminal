using Blog.Models;
using Microsoft.Data.SqlClient;
using Opw.HttpExceptions;

namespace Blog.Repositories;

public class UserRoleRepository
{
    private readonly SqlConnection _connection;

    public UserRoleRepository(SqlConnection connection)
        => _connection = connection;
    
    public int InsertUserRole(string userEmail, string roleSlug)
    {
        UserRepository userRepository = new UserRepository(_connection);
        RoleRepository roleRepository = new RoleRepository(_connection);

        var userId = userRepository.GetIdByEmail(userEmail);
        if (userId == null)
            throw new NotFoundException($"User with email: {userEmail} not found!");

        var roleId = roleRepository.GetIdBySlug(roleSlug);
        if (roleId == null)
            throw new NotFoundException($"Role with slug: {roleSlug} not found!");
        
        // TODO: Chamar user repository , fazer select id,
        // TODO: Chamar role repository ,fazer select id
        // TODO: realizar insert com id's na userrole
        return 0;
        
        //SE REALIZAR INSERT RETORNAR 1, OU THROW EXCEPTION
        // SE NAO ENCONTRAR EMAIL RETORNAR 2,
        // SE NAO ENCONTRAR ROLE SLUG RETORNAR 3
    }

    public int InsertUserRole(int userId, string roleSlug)
    {
        // TODO: Chamar user repository , fazer select 1, se retornar, reutilizar ID
        // TODO: Chamar role repository ,fazer select id
        // TODO: realizar insert com id's na userrole
        return 0;
    }
}