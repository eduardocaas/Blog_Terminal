﻿using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRoleRepository
{
    private readonly SqlConnection _connection;

    public UserRoleRepository(SqlConnection connection)
        => _connection = connection;

    public int InsertUserRole(string userEmail, string roleSlug)
    {
        return 0;
    }

    public int InsertUserRole(int userId, string roleSlug)
    {
        return 0;
    }
}