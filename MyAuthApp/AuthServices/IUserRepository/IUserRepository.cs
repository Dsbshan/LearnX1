
using AuthIservices.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

public interface IUserRepository

{
    int Register(UserModel user);
    UserModel Login(UserModel usrl);
    UserModel GetUserByEmail(string email);
}




    
