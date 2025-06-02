using AuthIservices.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MyDb");
    }

    public int Register(UserModel user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@UserName", user.UserName);
            parameters.Add("@Password", user.Password);

            return connection.QuerySingle<int>("[dbo].[Register]", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public UserModel Login(UserModel usrl)
    {
        using (var connection = new SqlConnection(_connectionString))
        {

            var parameters = new DynamicParameters();

            parameters.Add("@Email", usrl.Email);
            parameters.Add("@Password", usrl.Password);

            return connection.QueryFirstOrDefault<UserModel>("[dbo].[Login]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
    public UserModel GetUserByEmail(string email)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            return connection.QueryFirstOrDefault<UserModel>(
                "[dbo].[GetUserByEmail]",
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }


}