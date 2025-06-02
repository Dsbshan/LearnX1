using CustomAuh.Entities;
using CustomAuh.Helpers;
using CustomAuh.Models;
using CustomAuth.Services.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CustomAuth.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly DatabaseHelper _dbHelper;

        public AccountService(DatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<IEnumerable<UserAccount>> GetAllUsers()
        {
            return await _dbHelper.QueryAsync<UserAccount>("[dbo].[GetAllUsers]");
        }

        public async Task Register(RegistrataionViewModel model)
        {
            try
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new ApplicationException("Please enter a unique Email or Username", ex);
            }
        }

        public async Task<UserAccount> Login(LoginViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserNameOrEmail", model.UserNameOrEmail);
                parameters.Add("@Password", model.Password);

                var user = await _dbHelper.QuerySingleAsync<UserAccount>("[dbo].[AuthenticateUser]", parameters);

                return user ?? throw new ApplicationException("Invalid username/email or password");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred during login. Please try again later.", ex);
            }
        }
    }
}