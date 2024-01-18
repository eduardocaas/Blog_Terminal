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

        var query = "INSERT INTO [UserRole] VALUES(@user, @role)";
        
        //ver retorno desse execute, por padrao se violar PK no db vai lançar exception a nivel de db, (user try catch)
        _connection.Execute(query, new { user = userId, role = roleId });
        
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