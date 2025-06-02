using CustomAuh.Entities;
using CustomAuh.Helpers;
using CustomAuh.Infrastructure.Data;
using CustomAuh.Models;
using Dapper;

namespace CustomAuth.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public UserRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<IEnumerable<UserAccount>> GetAllUsers()
        {
            return await _dbHelper.QueryAsync<UserAccount>("[dbo].[GetAllUsers]");
        }

        public async Task RegisterUser(RegistrataionViewModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", model.Email);
            parameters.Add("@FirstName", model.FirstName);
            parameters.Add("@LastName", model.LastName);
            parameters.Add("@Password", model.Password);
            parameters.Add("@UserName", model.UserName);
            parameters.Add("@Role", model.Role);

            await _dbHelper.ExecuteAsync("[dbo].[RegisterUser]", parameters);
        }

        public async Task<UserAccount> AuthenticateUser(string usernameOrEmail, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserNameOrEmail", usernameOrEmail);
            parameters.Add("@Password", password);

            return await _dbHelper.QuerySingleAsync<UserAccount>("[dbo].[AuthenticateUser]", parameters);
        }

        public async Task<IEnumerable<UserAccount>> GetAllUsersAsync()
        {
            return await GetAllUsers(); // You can either call the existing method or implement separately
        }
    }
}